using System;
using System.Collections.Generic;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace ThreadManager
{
    public partial class Form1 : Form
    {
        public int[] Array;
        public List<Thread> Threads = new List<Thread>();
        private Semaphore semaphore;

        public Form1()
        {
            InitializeComponent();
            semaphore = new Semaphore(1, 1);
        }

        static int[] GenerateRandomArray(int N, int a, int b)
        {
            Random random = new Random();
            int[] array = new int[N];

            for (int i = 0; i < N; i++)
            {
                array[i] = random.Next(a, b + 1);
            }

            return array;
        }

        static void SelectionSort(int[] array)
        {
            int n = array.Length;

            for (int i = 0; i < n - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (array[j] < array[minIndex])
                    {
                        minIndex = j;
                    }
                }

                if (minIndex != i)
                {
                    int temp = array[i];
                    array[i] = array[minIndex];
                    array[minIndex] = temp;
                }
            }
        }

        public void SetComboBox(int ThreadsCount)
        {
            comboBoxThreads.Items.Clear();
            for (int i = 0; i < ThreadsCount; i++)
            {
                comboBoxThreads.Items.Add(i);
            }
        }

        static void PrintArray(RichTextBox richTextBox, int[] array)
        {
            richTextBox.Clear();
            foreach (var item in array)
            {
                richTextBox.AppendText(item.ToString() + " ");
            }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            int N = Int32.Parse(textBoxN.Text);
            int ThreadsCount = Int32.Parse(textBoxThreadsCount.Text);

            // Генеруємо масив
            Array = GenerateRandomArray(N, -100, 100);
            PrintArray(richTextBoxArray, Array);

            // Створюємо Memory-Mapped файл
            using (var mmf = MemoryMappedFile.CreateOrOpen("SharedMemory", N * sizeof(int)))
            {
                int chunkSize = N / ThreadsCount;
                SetComboBox(ThreadsCount);
                List<int[]> sortedParts = new List<int[]>();

                for (int i = 0; i < ThreadsCount; i++)
                {
                    int start = i * chunkSize;
                    int end = (i == ThreadsCount - 1) ? N : (i + 1) * chunkSize;
                    int[] part = Array.Skip(start).Take(end - start).ToArray();

                    // Кожен потік сортує свою частину масиву
                    Thread thread = new Thread(() =>
                    {
                        SelectionSort(part);

                        // Записуємо відсортовану частину у Memory-Mapped файл
                        semaphore.WaitOne();
                        using (var accessor = mmf.CreateViewAccessor(start * sizeof(int), part.Length * sizeof(int)))
                        {
                            for (int j = 0; j < part.Length; j++)
                            {
                                accessor.Write(j * sizeof(int), part[j]);
                            }
                        }
                        semaphore.Release();
                    });

                    Threads.Add(thread);
                    thread.Start();
                }

                // Чекаємо завершення всіх потоків
                foreach (Thread thread in Threads)
                {
                    thread.Join();
                }

                // Зчитуємо масив із Memory-Mapped файла
                Array = new int[N];
                using (var accessor = mmf.CreateViewAccessor())
                {
                    for (int i = 0; i < N; i++)
                    {
                        Array[i] = accessor.ReadInt32(i * sizeof(int));
                    }
                }

                // Виводимо відсортований масив у RichTextBox
                PrintArray(richTextBoxSortedArray, Array);

                // Записуємо відсортований масив у файл SortedArray.dat
                SaveArrayToFile("SortedArray.dat", Array);
            }
        }

        private void SaveArrayToFile(string fileName, int[] array)
        {
            using (var writer = new BinaryWriter(File.Open(fileName, FileMode.Create)))
            {
                foreach (var item in array)
                {
                    writer.Write(item);
                }
            }
            MessageBox.Show($"Результати збережено у файл {fileName}.");
        }

        private void buttonChangePriority_Click(object sender, EventArgs e)
        {
            if (comboBoxThreads.SelectedIndex == -1 || comboBoxPriority.SelectedIndex == -1)
            {
                MessageBox.Show("Будь ласка, виберіть потік та пріоритет.");
                return;
            }

            int selectedThreadIndex = comboBoxThreads.SelectedIndex;
            Thread selectedThread = Threads[selectedThreadIndex];

            if (!selectedThread.IsAlive)
            {
                MessageBox.Show("Цей потік вже завершив свою роботу. Пріоритет не можна змінити.");
                return;
            }

            ThreadPriority priority = ThreadPriority.Normal;
            switch (comboBoxPriority.SelectedItem.ToString())
            {
                case "Lowest":
                    priority = ThreadPriority.Lowest;
                    break;
                case "BelowNormal":
                    priority = ThreadPriority.BelowNormal;
                    break;
                case "Normal":
                    priority = ThreadPriority.Normal;
                    break;
                case "AboveNormal":
                    priority = ThreadPriority.AboveNormal;
                    break;
                case "Highest":
                    priority = ThreadPriority.Highest;
                    break;
            }

            selectedThread.Priority = priority;
            MessageBox.Show($"Пріоритет потоку {selectedThreadIndex} змінено на {priority.ToString()}");
        }
    }
}

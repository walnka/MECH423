using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Concurrent;

namespace Mech423Lab1Exercise2
{
    public partial class QueueTest : Form
    {
        ConcurrentQueue<Int32> dataQueue = new ConcurrentQueue<Int32>();
        public QueueTest()
        {
            InitializeComponent();
        }

        private void EnqueueButton_Click(object sender, EventArgs e)
        {
            dataQueue.Enqueue(Convert.ToInt32(QueueInput.Text));
        }

        private void DequeueButton_Click(object sender, EventArgs e)
        {
            int dequeueResult;
            if (!dataQueue.TryDequeue(out dequeueResult))
            {
                MessageBox.Show("The queue is currently empty.\r\nCan not dequeue!", "Empty Queue");
            }
            else
            {
                QueueOutput.Text = dequeueResult.ToString();
            }
        }

        private void UpdateQueue(object sender, EventArgs e)
        {
            ContentsOutput.Clear();
            QueueLengthOutput.Text = dataQueue.Count().ToString();
            foreach (var item in dataQueue)
            {
                ContentsOutput.AppendText(item.ToString() + ", ");
            }
        }

        private void AverageButton_Click(object sender, EventArgs e)
        {
            int n = Convert.ToInt32(NInput.Text);
            int sum = 0;
            int dequeueResult;

            if ((n <= dataQueue.Count()) && (n > 0))
            {
                for (int i = 0; i < n; i++)
                {
                    dataQueue.TryDequeue(out dequeueResult);
                    sum += dequeueResult; 
                }
                AverageOutput.Text = ((decimal)(sum) / n).ToString();
            }
            else
            {
                MessageBox.Show("There are not enough items in the queue to average the first " + n.ToString() + " items.\r\nChoose an N value less than or equal to the number of items in the queue and greater than 0", "Not Enough Items in Queue");
            }
        }
    }
}

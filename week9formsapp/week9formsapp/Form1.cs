using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace week9formsapp
{
    public partial class Form1 : Form
    {
        List<Entities.Person> Population = new List<Entities.Person>();
        List<Entities.BirthProbability> BirthProbabilities = new List<Entities.BirthProbability>();
        List<Entities.DeathProbability> DeathProbabilities = new List<Entities.DeathProbability>();

        Random rng = new Random(1234);

        public Form1()
        {
            InitializeComponent();

            Population = GetPopulation(@"C:\Temp\nép.csv");
            BirthProbabilities = GetBirthProbabilities(@"C:\Temp\születés.csv");
            DeathProbabilities = GetDeathProbabilities(@"C:\Temp\halál.csv");

            dataGridView1.DataSource = BirthProbabilities;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public List<Entities.Person> GetPopulation(string csvpath)
        {
            List<Entities.Person> population = new List<Entities.Person>();

            using (StreamReader sr = new StreamReader(csvpath, Encoding.Default))
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine().Split(';');
                    population.Add(new Entities.Person()
                    {
                        BirthYear = int.Parse(line[0]),
                        Gender = (Entities.Gender)Enum.Parse(typeof(Entities.Gender), line[1]),
                        NbrOfChildren = int.Parse(line[2])
                    });
                }
            }

            return population;
        }

        public List<Entities.BirthProbability> GetBirthProbabilities(string csvpath)
        {
            List<Entities.BirthProbability> szuletesval = new List<Entities.BirthProbability>();

            using (StreamReader sr = new StreamReader(csvpath, Encoding.Default))
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine().Split(';');
                    szuletesval.Add(new Entities.BirthProbability()
                    {
                        Age = int.Parse(line[0]),
                        gyerekSzam = int.Parse(line[1]),
                        P = double.Parse(line[2])
                    });
                }
            }

            return szuletesval;
        }

        public List<Entities.DeathProbability> GetDeathProbabilities(string csvpath)
        {
            List<Entities.DeathProbability>halalval = new List<Entities.DeathProbability>();

            using (StreamReader sr = new StreamReader(csvpath, Encoding.Default))
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine().Split(';');
                    halalval.Add(new Entities.DeathProbability()
                    {
                        Gender = (Entities.Gender)Enum.Parse(typeof(Entities.Gender), line[0]),
                        Age = int.Parse(line[1]),
                        P = double.Parse(line[2])
                    });
                }
            }

            return halalval;
        }
    }
}

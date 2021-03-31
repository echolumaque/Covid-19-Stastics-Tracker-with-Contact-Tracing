using Plugin.FilePicker;
using Plugin.FilePicker.Abstractions;
using System;
using System.ComponentModel;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace NcoVAppUpdate
{
    public class ContactTracingMainVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ContactTracingMainVM()
        {
            RDPositive = new Command(RDPositiveClick);
            RDPending = new Command(RDPendingClick);
            RDPUI = new Command(RDPUIClick);
            RDPUM = new Command(RDPUMClick);

            OpenSymptomsExpander = new Command(Open);
            HideSymptomsExpander = new Command(Close);

            GetProof = new Command(async () => await GetProofAsync());
            SendProof = new Command(async () => await SendproofAsync());
        }
        string triage;
        public string Triage
        {
            get { return triage; }
            set
            {
                if (triage != value)
                {
                    triage = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Triage"));
                }
            }
        }
        public Command RDPositive { get; }
        public Command RDPending { get; }
        public Command RDPUI { get; }
        public Command RDPUM { get; }

        void RDPositiveClick()
        {
            Triage = "Positive";
        }
        void RDPendingClick()
        {
            Triage = "Pending";
        }
        void RDPUIClick()
        {
            Triage = "Person under investigation";
        }
        void RDPUMClick()
        {
            Triage = "Person under monitoring";
        }

        bool symptomsExpanderVisible;
        public bool SymptomsExpanderVisible
        {
            get { return symptomsExpanderVisible; }
            set
            {
                if (symptomsExpanderVisible != value)
                {
                    symptomsExpanderVisible = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SymptomsExpanderVisible"));
                }

            }
        }
        public Command OpenSymptomsExpander { get; }
        void Open()
        {
            SymptomsExpanderVisible = true;
        }

        public Command HideSymptomsExpander { get; }
        void Close()
        {
            SymptomsExpanderVisible = false;
        }

        string feverSymptoms;
        public string FeverSymptoms
        {
            get => feverSymptoms;
            set
            {
                if (feverSymptoms != value)
                {
                    feverSymptoms = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FeverSymptoms"));
                }
            }
        }
        bool fever;
        public bool Fever
        {
            get => fever;
            set
            {
                if (fever != value)
                {
                    fever = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Fever"));
                }
                if (fever)
                {
                    FeverSymptoms = "Fever, ";
                }
            }
        }

        string dryCoughSymptoms;
        public string DryCoughSymptoms
        {
            get => dryCoughSymptoms;
            set
            {
                if (dryCoughSymptoms != value)
                {
                    dryCoughSymptoms = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("DryCoughSymptoms"));
                }
            }
        }
        bool dryCough;
        public bool DryCough
        {
            get => dryCough;
            set
            {
                if (dryCough != value)
                {
                    dryCough = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("DryCough"));
                }
                if (dryCough)
                {
                    DryCoughSymptoms = "Dry cough, ";
                }
            }
        }

        string tirednessSymptoms;
        public string TirednessSymptoms
        {
            get => tirednessSymptoms;
            set
            {
                if (tirednessSymptoms != value)
                {
                    tirednessSymptoms = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("TirednessSymptoms"));
                }
            }
        }
        bool tiredness;
        public bool Tiredness
        {
            get => tiredness;
            set
            {
                if (tiredness != value)
                {
                    tiredness = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Tiredness"));
                }
                if (tiredness)
                {
                    TirednessSymptoms = "Tiredness, ";
                }
            }
        }

        string soreThroatSymptoms;
        public string SoreThroatSymptoms
        {
            get => soreThroatSymptoms;
            set
            {
                if (soreThroatSymptoms != value)
                {
                    soreThroatSymptoms = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SoreThroatSymptoms"));
                }
            }
        }
        bool soreThroat;
        public bool SoreThroat
        {
            get => soreThroat;
            set
            {
                if (soreThroat != value)
                {
                    soreThroat = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SoreThroat"));
                }
                if (soreThroat)
                {
                    SoreThroatSymptoms = "Sore throat, ";
                }
            }
        }

        string difficultyBreathingSymptoms;
        public string DifficultyBreathingSymptoms
        {
            get => difficultyBreathingSymptoms;
            set
            {
                if (difficultyBreathingSymptoms != value)
                {
                    difficultyBreathingSymptoms = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("DifficultyBreathingSymptoms"));
                }
            }
        }
        bool difficultyBreathing;
        public bool DifficultyBreathing
        {
            get => difficultyBreathing;
            set
            {
                if (difficultyBreathing != value)
                {
                    difficultyBreathing = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("DifficultyBreathing"));
                }
                if (difficultyBreathing)
                {
                    DifficultyBreathingSymptoms = "Difficulty breathing, ";
                }
            }
        }
        public Command GetProof { get; }
        public string FileProof { get; set; }
        async System.Threading.Tasks.Task GetProofAsync()
        {
            try
            {
                FileData proof = await CrossFilePicker.Current.PickFile();
                FileProof = proof.FilePath;
            }
            catch (Exception)
            {
                await Application.Current.MainPage.DisplayAlert("", "Error in file handling", "Okay");
            }
        }
        public Command SendProof { get; }
        async System.Threading.Tasks.Task SendproofAsync()
        {
            string recipient = "jjnlumaque@iskolarngbayan.pup.edu.ph";
            try
            {
                string sub = Triage;
                string body = string.Format("A {0} person with a symptom of {1}{2}{3}{4}{5} is currently at {6} {7}, {8}", Triage, FeverSymptoms, DryCoughSymptoms, TirednessSymptoms, SoreThroatSymptoms, DifficultyBreathingSymptoms, AddressLine1, Barangay, Municipality);
                EmailMessage message = new EmailMessage(sub, body, recipient);
                message.Attachments.Add(new EmailAttachment(FileProof));
                await Email.ComposeAsync(message);
                await Application.Current.MainPage.DisplayAlert("Notice", "Your submitted proof will be verified and will be added on map upon confirmation. Thank you for your cooperation!", "Okay");
            }
            catch (Exception)
            {
                await Application.Current.MainPage.DisplayAlert("", "Invalid inputs!", "Okay");
            }
        }
        string addressLine1;
        public string AddressLine1
        {
            get => addressLine1;
            set
            {
                if (addressLine1 != value)
                {
                    addressLine1 = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("AddressLine1"));
                }
            }
        }
        string barangay;
        public string Barangay
        {
            get => barangay;
            set
            {
                if (barangay != value)
                {
                    barangay = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Barangay"));
                }
            }
        }
        string municipality;
        public string Municipality
        {
            get => municipality;
            set
            {
                if (municipality != value)
                {
                    municipality = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Municipality"));
                }
            }
        }
    }
}
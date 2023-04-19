using System.ComponentModel;

namespace FinalProject.ViewModel
{
    public class ViewModel : INotifyPropertyChanged

    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ViewModel() 
        {
            
        }

        string textinput;
        public string TextInput
        {
            get { return textinput; }
            set 
            { 
                textinput = value; 
                onPropertyChanged(nameof(TextInput));
            }
        }
        

        void onPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        
    }
}

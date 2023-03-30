using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TaskApp.ViewModel;

public class BaseViewModel : INotifyPropertyChanged
{
    bool _isBusy;
    string _title;

    public bool isBusy
    {
        get => _isBusy;
        set
        {
            if (_isBusy == value)
                return;
            _isBusy = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(isNotBusy));
        }
    }

    public bool isNotBusy => !isBusy;
    public string title
    {
        get => _title;
        set
        {
            if (_title == value)
                return;
            _title = value;
            OnPropertyChanged();
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    //gets caller name in this case isBusy or title if didn't set value
    public void OnPropertyChanged([CallerMemberName]string name = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}

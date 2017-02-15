using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace UwpTogglebuttonOneway
{
    public class MainViewModel : ViewModelBase
    {
        private int _evenOrOddIndex;

        public ObservableCollection<EvenOrOdd> ListOfEvenOrOdd { get; } = new ObservableCollection<EvenOrOdd>();
        public EvenOrOdd CurrentEvenOrOdd { get; set; }

        public RelayCommand SelectPreviousItemCommand { get; }
        public RelayCommand SelectNextItemCommand { get; }
        public RelayCommand ToggleItemCommand { get; }

        public MainViewModel()
        {
            ListOfEvenOrOdd.Add(new EvenOrOdd { IsEven = true });
            ListOfEvenOrOdd.Add(new EvenOrOdd { IsEven = null });
            ListOfEvenOrOdd.Add(new EvenOrOdd { IsEven = false });
            ListOfEvenOrOdd.Add(new EvenOrOdd { IsEven = true });
            ListOfEvenOrOdd.Add(new EvenOrOdd { IsEven = null });
            ListOfEvenOrOdd.Add(new EvenOrOdd { IsEven = false });

            _evenOrOddIndex = 0;
            CurrentEvenOrOdd = ListOfEvenOrOdd[_evenOrOddIndex];

            SelectPreviousItemCommand = new RelayCommand(SelectPreviousItem, CanSelectPreviousItem);
            SelectNextItemCommand = new RelayCommand(SelectNextItem, CanSelectNextItem);
            ToggleItemCommand = new RelayCommand(ToggleItem);

            SelectPreviousItemCommand.RaiseCanExecuteChanged();
            SelectNextItemCommand.RaiseCanExecuteChanged();
        }

        private bool CanSelectPreviousItem()
        {
            return _evenOrOddIndex > 0;
        }
        private void SelectPreviousItem()
        {
            _evenOrOddIndex--;
            CurrentEvenOrOdd = ListOfEvenOrOdd[_evenOrOddIndex];
            RaisePropertyChanged(nameof(CurrentEvenOrOdd));

            SelectPreviousItemCommand.RaiseCanExecuteChanged();
            SelectNextItemCommand.RaiseCanExecuteChanged();
        }

        private bool CanSelectNextItem()
        {
            return _evenOrOddIndex < ListOfEvenOrOdd.Count - 1;
        }
        private void SelectNextItem()
        {
            _evenOrOddIndex++;
            CurrentEvenOrOdd = ListOfEvenOrOdd[_evenOrOddIndex];
            RaisePropertyChanged(nameof(CurrentEvenOrOdd));

            SelectPreviousItemCommand.RaiseCanExecuteChanged();
            SelectNextItemCommand.RaiseCanExecuteChanged();
        }

        private void ToggleItem()
        {
            CurrentEvenOrOdd.IsEven = !(CurrentEvenOrOdd.IsEven.HasValue && CurrentEvenOrOdd.IsEven.Value);
            RaisePropertyChanged(nameof(CurrentEvenOrOdd));
        }
    }
}

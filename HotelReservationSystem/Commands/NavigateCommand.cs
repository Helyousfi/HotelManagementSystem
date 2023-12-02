using HotelReservationSystem.Stores;
using HotelReservationSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationSystem.Commands
{
    /// <summary>
    /// The command used when we click the button "Make reservation" in reservaation listing view
    /// </summary>
    public class NavigateCommand : CommandBase
    {
        private readonly NavigationStore _navigationStore;
        public NavigateCommand(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
        }
        public override void Execute(object? parameter)
        {
            _navigationStore.CurrentViewModel = 
                new MakeReservViewModel(new Models.Hotel("", ""), 
                _navigationStore);
        }
    }
}

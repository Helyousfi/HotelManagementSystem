using HotelReservationSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationSystem.Commands
{
    internal class DeleteCommand : CommandBase
    {
        private readonly ReservListingViewModel _viewModel;
        public DeleteCommand(ReservListingViewModel viewModel)
        {
            _viewModel = viewModel;
        }
        public override void Execute(object? parameter)
        {
            _viewModel.RemoveSelectedReservation();
        }
    }
}

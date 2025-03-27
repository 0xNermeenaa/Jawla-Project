using AutoMapper;
using Infrastructure.DTO;
using Infrastructure.Models;
using Repository.IRepositories;
using Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Service
{
    public interface IReservationService
    {
        Task<reservationDTO> AddReservation(reservationDTO reservation);
    }






    //--------------------------------------------------------------------------//


    public class ReservationService : IReservationService
    {

        private readonly IReservationRepository _ReservationRepository;
        public readonly IPaymentService _PaymentService;
        private readonly IMapper _Mapper;

        public ReservationService(IReservationRepository Reservation, IMapper mapper, IPaymentService paymentService)
        {
            _Mapper = mapper;
            _ReservationRepository = Reservation;
            _PaymentService = paymentService;
        }

        //----------------------------------------------------------


        public async Task<reservationDTO> AddReservation(reservationDTO reservation)
        {
            Reservation rese = null;
            

          var pay= await _PaymentService.GetPayment(reservation.PaymentId);
            if (pay == null) { throw new ArgumentException("Invalid payment"); }

            var res = _Mapper.Map<Reservation>(reservation);

            if (res != null)
            {
                rese = await _ReservationRepository.AddAsync(res);
            }

            if (rese != null) 
            {
                return _Mapper.Map<reservationDTO>(rese);
            }

            return null; 
        }

        


    }
}

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
    public interface IPaymentService
    {
        Task<PaymentDTO> AddPayment(PaymentDTO payment);
        Task<Payment> GetPayment(int id);
    }






    //--------------------------------------------------------------------------//


    public class PaymentService:IPaymentService
    {

        private readonly IPaymentRepository _paymentRepository;
        private readonly IMapper _Mapper;

        public PaymentService(IPaymentRepository payment,IMapper mapper)
        {
            _Mapper = mapper;
            _paymentRepository = payment;
        }

//----------------------------------------------------------




        public async Task<PaymentDTO> AddPayment(PaymentDTO payment)
        {
            var p=_Mapper.Map<Payment>(payment);
            if (p == null) 
            
            { throw new ArgumentException("Invalid payment object. Please check the details and try again."); }

           var pa= await _paymentRepository.AddAsync(p);
            if (pa == null) { throw new ArgumentException("Invalid payment object. Please check the details and try again."); }
         return _Mapper.Map<PaymentDTO>(pa);

        }

        public async Task<Payment>GetPayment(int id) 
        {
        
        var p=await _paymentRepository.GetByIdAsync(id);
            if (p == null) { throw new ArgumentException("not found"); }
            return p;
        
        }

    }
}

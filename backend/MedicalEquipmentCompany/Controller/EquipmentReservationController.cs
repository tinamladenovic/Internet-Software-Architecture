using System.Drawing.Imaging;
using System.Drawing;
using MedicalEquipmentCompany.Model.Dtos;
using MedicalEquipmentCompany.Service.Base;
using MedicalEquipmentCompany.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QRCoder;
using ZXing.QrCode.Internal;
using MedicalEquipmentCompany.Service;
using MedicalEquipmentCompany.Model.Result;
using MedicalEquipmentCompany.Model;

namespace MedicalEquipmentCompany.Controller
{
    [ApiController]
   
    [Route("api/equipmentReservation")]
    public class EquipmentReservationController : BaseApiController
    {
        private readonly IEquipmentReservationService _equipmentReservationService;
        private readonly IUserService _userService;
        private readonly IEmailService _emailService;
        private readonly IEquipmentService _equipmentService;
        private readonly IEquipmentPickupService _equipmentPickupService;
        public EquipmentReservationController(IEquipmentReservationService equipmentReservationService, IUserService userService, IEmailService emailService, IEquipmentService equipmentService,  IEquipmentPickupService equipmentPickupService)
        {
            _equipmentReservationService = equipmentReservationService;
            _userService = userService;
            _emailService = emailService;
            _equipmentService = equipmentService;
            _equipmentPickupService = equipmentPickupService;
        }


        [HttpGet]
        public ActionResult<PagedResult<EquipmentReservationDto>> GetAll([FromQuery] int page, [FromQuery] int pageSize)
        {
            var result = _equipmentReservationService.GetPaged(page, pageSize);
            return CreateResponse(result);
        }


        [HttpPost]
        public ActionResult<EquipmentReservationDto> Create([FromBody] EquipmentReservationDto reservation)
        {
            var result = _equipmentReservationService.Create(reservation);
            var equipment = _equipmentService.Get((int)result.Value.ReservedEquipment[0]);
            equipment.Value.QuantityInStock -= reservation.EquipmentCount.Count;
            var pickup = _equipmentPickupService.Get((int)reservation.EquipmentPickup);
            pickup.Value.IsReserved = true;
            string reservationInfo = $"Reservation ID: {result.Value.Id}\nReservation date: {result.Value.ReservationDate}\nEquipment: {equipment.Value.Name}\nEquipment count: {result.Value.EquipmentCount.Count}\nStart Date: {result.Value.ReservationDate}\nStatus: {result.Value.ReservationStatus}";
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(reservationInfo, QRCodeGenerator.ECCLevel.Q);
            BitmapByteQRCode qrCode = new BitmapByteQRCode(qrCodeData);

            // Attach the QR code image to the email
            _emailService.SendEmailWithAttachment(_userService.Get((int)reservation.UserId).Value, "Your Reservation Details", "Please find your reservation details attached.", qrCode.GetGraphic(20), "QRCode.png");
            return CreateResponse(result);
        }

        [HttpPut("{id:int}")]
        public ActionResult<EquipmentReservationDto> Update([FromBody] EquipmentReservationDto reservation)
        {
            var result = _equipmentReservationService.Update(reservation);
            var equipment = _equipmentService.Get((int)result.Value.ReservedEquipment[0]);
            equipment.Value.QuantityInStock -= reservation.EquipmentCount.Count;
           
            string reservationInfo = $"Reservation ID: {result.Value.Id}\nReservation date: {result.Value.ReservationDate}\nEquipment: {equipment.Value.Name}\nEquipment count: {result.Value.EquipmentCount.Count}\nStart Date: {result.Value.ReservationDate}\nStatus: {result.Value.ReservationStatus}";
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(reservationInfo, QRCodeGenerator.ECCLevel.Q);
            BitmapByteQRCode qrCode = new BitmapByteQRCode(qrCodeData);

            
            _emailService.SendEmailWithAttachment(_userService.Get((int)reservation.UserId).Value, "Your Reservation Details", "Please find your reservation details attached.", qrCode.GetGraphic(20), "QRCode.png");
            
            return CreateResponse(result);
        }


    }
}

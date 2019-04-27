﻿using AbstractFlowerShopServiceDAL1.BindingModel;
using AbstractFlowerShopServiceDAL1.Interfaces;
using System;
using System.Threading;

namespace AbstractFlowerShopRestApi.Services
{
    public class WorkExecutor
    {
        private readonly IServiceMain _service;
        private readonly IExecutorService _serviceExecutor;
        private readonly int _executorId;
        private readonly int _bookingId;
        // семафор
        static Semaphore _sem = new Semaphore(3, 3);
        Thread myThread;
        public WorkExecutor(IServiceMain service, IExecutorService
       serviceExecutor, int executorId, int bookingId)
        {
            _service = service;
            _serviceExecutor = serviceExecutor;
            _executorId = executorId;
            _bookingId = bookingId;
            try
            {
                _service.TakeBookingInWork(new BookingBindingModel
                {
                    Id = _bookingId,
                    ExecutorId = _executorId
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            myThread = new Thread(Work);
            myThread.Start();
        }
        public void Work()
        {
            try
            {
                // забиваем мастерскую
                _sem.WaitOne();
                // Типа выполняем
                Thread.Sleep(10000);
                _service.FinishBooking(new BookingBindingModel
                {
                    Id = _bookingId
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                // освобождаем мастерскую
                _sem.Release();
            }
        }
    }
}

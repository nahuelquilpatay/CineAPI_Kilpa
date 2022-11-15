﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Dominio
{
    public class Ticket
    {
        public int TicketNro { get; set; }
        public List<DetalleTicket> Detalles { get; set; }
        public int Pago { get; set; }

        public int Activo { get; set; }
       
        //public TipoPago Pago { get; set; } VER


        //public Cliente Cliente { get; set; } VER

        public int Cliente { get; set; }
        public DateTime Fecha { get; set; }

        public Ticket()
        {
            Detalles = new List<DetalleTicket>();
            Pago = 0;
            Cliente = 0;
            Fecha = DateTime.Now;
        }

        public void AgregarDetalle(DetalleTicket detalle)
        {
            Detalles.Add(detalle);
        }

        public void QuitarDetalle(int posicion)
        {
            Detalles.RemoveAt(posicion);
        }

        public int CantidadDetalles()
        {
            return Detalles.Count;
        }
        public double CalcularSubTotal()
        {
            double total = 0;
            foreach (DetalleTicket item in Detalles)
            {
                total = total + item.Costo;
            }

            return total;
        }


    }
}


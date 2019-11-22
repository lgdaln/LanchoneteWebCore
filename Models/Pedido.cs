﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LanchoneteCore.Models
{
    public class Pedido
    {
        [Key]
        public int PedidoID { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Data")]
        public DateTime Data { get; set; }
        [Display(Name = "Hora")]
        public String Hora { get; set; }
        [Display(Name = "Status")]
        public String Statusp { get; set; }
        [Display(Name = "Valor")]
        public double ValorAtual { get; set; }
        public int AtendenteID { get; set; }

        public Atendente Atendente { get; set; }
        public int ClienteID { get; set; }

        public Cliente Cliente { get; set; }
        public int ProdutoID { get; set; }
        public Produto Produto { get; set; }

        public Pedido()
        {
        }

        public Pedido(int pedidoID, DateTime data, String hora, String statusp, double valorAtual, int atendenteID, Atendente atendente, int clienteID, Cliente cliente, int produtoID, Produto produto)
        {
            PedidoID = pedidoID;
            Data = data;
            Hora = hora;
            Statusp = statusp;
            ValorAtual = valorAtual;
            AtendenteID = atendenteID;
            Atendente = atendente;
            ClienteID = clienteID;
            Cliente = cliente;
            ProdutoID = produtoID;
            Produto = produto;
        }
    }
}

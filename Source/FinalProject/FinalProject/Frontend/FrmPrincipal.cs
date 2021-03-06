﻿using FinalProject.Backend;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject.Frontend
{
    public partial class FrmPrincipal : Form
    {
        Tutor tutor = null;
        bool CerrarApp = true;

        public FrmPrincipal(int IdTutor)
        {
            InitializeComponent();
            Init(Tutor.Select(IdTutor));
        }

        private void Init(Tutor tutor)
        {
            this.tutor = tutor;
            lblMensajeBienvenida.Text = String.Format("Bienvenido, {0}!", tutor.Nombre);

            CargarListaAsesorias();
        }
        private void CargarListaAsesorias()
        {
            dtListaAsesorias.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        }

        private void btnAdministrar_Click(object sender, EventArgs e)
        {
            (new FrmListaAsesores(tutor.IdTutor)).ShowDialog();
        }
        private void lnkSalir_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CerrarApp = false;
            this.Close();
        }
        private void FrmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (CerrarApp)
                Application.Exit();
        }
    }
}

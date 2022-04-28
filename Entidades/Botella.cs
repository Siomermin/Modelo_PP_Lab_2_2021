using System;
using System.Text;
//namespace Entidades
//{
    namespace Entidades.Botellas
    {
        public abstract class Botella
        {
            protected int capacidad;
            protected int contenido;
            protected string marca;
            protected double precio;

            public Botella(string marca, double precio) : this(marca, precio, 1000)
            {


            }

            public Botella(string marca, double precio, int capacidad)
            {
                this.marca = marca;
                this.precio = precio;
                this.capacidad = capacidad;
                this.contenido = capacidad;
            }

            public abstract double Ganancia
            {
                get;
            }

            public double PorcentajeContenido
            {
                get
                {
                    return this.contenido * 100 / this.capacidad;
                }
            }

            protected abstract void ServirMedida();

            private static string ObtenerDatos(Botella b)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"Marca: {b.marca} - Precio: {b.precio} - Capacidad {b.capacidad}");
                sb.AppendLine($"Contenido: {b.contenido} - Porcentaje Contenido: {b.PorcentajeContenido}%");
                return sb.ToString();
            }

            public override string ToString()
            {
                return Botella.ObtenerDatos(this);
            }

            public static explicit operator string(Botella a)
            {
                return a.marca;
            }

            public static bool operator ==(Botella a, Botella b)
            {
                if (a is not null && b is not null)
                {
                    return a.marca == b.marca && a.capacidad == b.capacidad;
                }
                return false;
            }

            public static bool operator !=(Botella a, Botella b)
            {
                return !(a == b);
            }

            public static Botella operator --(Botella a)
            {
                if (a is not null)
                {
                    a.ServirMedida();
                }
                return a;
            }
        }
    }
//}
using BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class Program
    {
        static void Main(string[] args)
        {
            int op;

            do
            {
                Console.WriteLine("------------------------------------------------");
                Console.WriteLine("1.- ADD BANCO");
                Console.WriteLine("2.- UPDATE BANCO");
                Console.WriteLine("3.- DELETE BANCO");
                Console.WriteLine("4.- GET-ALL BANCO");
                Console.WriteLine("------------------------------------------------");
                Console.WriteLine("SELECCIONE UNA OPCION: ");
                op = int.Parse(Console.ReadLine());

                switch (op)
                {
                    case 1:
                        ML.Banco bancoAdd = new ML.Banco();

                        Console.WriteLine("INGRESE EL NOMBRE DEL BANCO: ");
                        bancoAdd.Nombre = Console.ReadLine();

                        Console.WriteLine("INGRESE EL NUMERO DE EMPLEADOS DEL BANCO: ");
                        bancoAdd.NoEmpleados = int.Parse(Console.ReadLine());

                        Console.WriteLine("INGRESE EL NUMERO DE SUCURSALES DEL BANCO: ");
                        bancoAdd.NoSucursales = int.Parse(Console.ReadLine());

                        Console.WriteLine("INGRESE EL ID DEL PAIS DEL BANCO: ");
                        bancoAdd.Pais = new ML.Pais();
                        bancoAdd.Pais.idPais = int.Parse(Console.ReadLine());

                        Console.WriteLine("INGRESE EL CAPITAL DEL BANCO: ");
                        bancoAdd.Capital = int.Parse(Console.ReadLine());

                        Console.WriteLine("INGRESE EL ID DE LA RAZON SOCIAL DEL BANCO: ");
                        bancoAdd.RazonSocial = new ML.RazonSocial();
                        bancoAdd.RazonSocial.idRazonSocial = int.Parse(Console.ReadLine());

                        Console.WriteLine("INGRESE EL NUMERO DE CLIENTES DEL BANCO: ");
                        bancoAdd.NoClientes = int.Parse(Console.ReadLine());

                        ML.Result resultAdd = BL.Banco.Add(bancoAdd);

                        if (resultAdd.Correct)
                        {
                            Console.WriteLine("El Banco ha sido agregado correctamente ");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("Ocurrio un problema al intentar registrar el Banco " + resultAdd.ErrorMessage);
                            Console.ReadKey();
                        }
                        break;

                    case 2:
                        ML.Banco bancoUpdate = new ML.Banco();

                        Console.WriteLine("INGRESE EL ID  DEL BANCO: ");
                        bancoUpdate.idBanco = int.Parse(Console.ReadLine());

                        Console.WriteLine("INGRESE EL NOMBRE DEL BANCO: ");
                        bancoUpdate.Nombre = Console.ReadLine();

                        Console.WriteLine("INGRESE EL NUMERO DE EMPLEADOS DEL BANCO: ");
                        bancoUpdate.NoEmpleados = int.Parse(Console.ReadLine());

                        Console.WriteLine("INGRESE EL NUMERO DE SUCURSALES DEL BANCO: ");
                        bancoUpdate.NoSucursales = int.Parse(Console.ReadLine());

                        Console.WriteLine("INGRESE EL ID DEL PAIS DEL BANCO: ");
                        bancoUpdate.Pais = new ML.Pais();
                        bancoUpdate.Pais.idPais = int.Parse(Console.ReadLine());

                        Console.WriteLine("INGRESE EL CAPITAL DEL BANCO: ");
                        bancoUpdate.Capital = int.Parse(Console.ReadLine());

                        Console.WriteLine("INGRESE EL ID DE LA RAZON SOCIAL DEL BANCO: ");
                        bancoUpdate.RazonSocial = new ML.RazonSocial();
                        bancoUpdate.RazonSocial.idRazonSocial = int.Parse(Console.ReadLine());

                        Console.WriteLine("INGRESE EL NUMERO DE CLIENTES DEL BANCO: ");
                        bancoUpdate.NoClientes = int.Parse(Console.ReadLine());

                        ML.Result resultUpdate = BL.Banco.Update(bancoUpdate);

                        if (resultUpdate.Correct)
                        {
                            Console.WriteLine("------------------------------------------------");
                            Console.WriteLine("El Banco ha sido actualizado correctamente ");
                            Console.WriteLine("------------------------------------------------");
                            Console.ReadKey();

                        }
                        else
                        {
                            Console.WriteLine("------------------------------------------------");
                            Console.WriteLine("Ocurrio un problema al intentar actualizar el Banco " + resultUpdate.ErrorMessage);
                            Console.WriteLine("------------------------------------------------");
                            Console.ReadKey();
                        }
                        break;

                    case 3:
                        Console.WriteLine("INGRESE EL ID DEL BANCO QUE DESEA ELIMINAR: ");
                        int idBanco = int.Parse(Console.ReadLine());

                        ML.Result resultDelete = BL.Banco.Delete(idBanco);

                        if (resultDelete.Correct)
                        {
                            Console.WriteLine("------------------------------------------------");
                            Console.WriteLine("EL BANCO SE ELIMINO CORRECTAMENTE");
                            Console.WriteLine("------------------------------------------------");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("------------------------------------------------");
                            Console.WriteLine("UCURRIO UN ERROR AL INTENTAR ELIMINAR EL BANCO " + resultDelete.ErrorMessage);
                        }
                        break;
                    case 4:
                        ML.Result resultALL = BL.Banco.GetAll();

                        if (resultALL.Correct)
                        {
                            foreach (ML.Banco banco in resultALL.Objects)
                            {
                                Console.WriteLine("------------------------------------------------");
                                Console.WriteLine("NOMBRE BANCO: " + banco.Nombre);
                                Console.WriteLine("NUMERO DE EMPLEADO: " + banco.NoEmpleados);
                                Console.WriteLine("NUMERO DE SUCURSALES: " + banco.NoSucursales);
                                Console.WriteLine("PAIS: " + banco.Pais.Nombre);
                                Console.WriteLine("CAPITAL: " + banco.Capital);
                                Console.WriteLine("RAZON SOCIAL: " + banco.RazonSocial.Nombre);
                                Console.WriteLine("NUMERO DE CLIENTES: " + banco.NoClientes);
                                Console.WriteLine("------------------------------------------------");
                            }
                        }

                        break;

                }
            } while (op <= 4 );

        }
    }
}

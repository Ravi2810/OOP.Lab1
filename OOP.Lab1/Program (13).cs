using System;

using OOP.Lab1.Particles;
using OOP.Lab1.ModelComponents;
using OOP.Lab1.Materials;

namespace OOP.Lab1
{
	class OOP
	{
		static void Main(string[] args)
		{
			DispersionData dData;
			dData.LaData = new double[] { -2.22e-7, 9260.0, 0.0};
			dData.TaData = new double[] { -2.28e-7, 5240.0, 0.0};
			dData.WMaxLa = 7.63916048e13;
			dData.WMaxTa = 3.0100793072e13;

			RelaxationData rData;
			rData.Bl = 1.3e-24;
			rData.Btn = 9e-13;
			rData.Btu = 1.9e-18;
			rData.BI = 1.2e-45;
			rData.W = 2.42e13;

			Material silicon = new Material(in dData, in rData);
			//Model object to set material hightemp and low temp
			Model model = new Model(silicon, 600, 100, 10);

			int numCells = 10;
			for(int i = 0; i < numCells; ++i)
            {
				//To add sensor and cell into model object
				model.AddSensor(i, 310);
				model.AddCell(10, 10, i);

            }
			//To setsurface and phonons 
			model.SetSurfaces(300);
			model.SetEmitPhonons(300, 1, 5e-9);

			Console.WriteLine(model);
			
		}
	}
}

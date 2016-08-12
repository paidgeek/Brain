﻿using System.Collections.Generic;

namespace Brain.Evolution.Selections
{
	public class RouletteWheelSelection : ISelection
	{
		public List<Chromosome> Select(List<Chromosome> chromosomes, int count)
		{
			var selected = new List<Chromosome>();
			var fitnessSum = 0.0;

			for (var i = 0; i < chromosomes.Count; i++) {
				fitnessSum += chromosomes[i].Fitness;
			}

			var wheel = new double[chromosomes.Count];
			var s = 0.0;

			for (var i = 0; i < chromosomes.Count; i++) {
				s += chromosomes[i].Fitness / fitnessSum;
				wheel[i] = s;
			}

			for (var i = 0; i < count; i++) {
				var prob = Util.RandomDouble();

				for (var j = 0; j < wheel.Length; j++) {
					if (prob <= wheel[j]) {
						selected.Add(chromosomes[j].Clone());
						break;
					}
				}
			}

			return selected;
		}
	}
}
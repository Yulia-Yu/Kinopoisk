using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Курсовой_Проект
{
    class HeshT
    {
		public int size;
		int k = 1;
		public Film[] h;

		public HeshT(int N)
		{
			size = N;
			h = new Film[size];
			//int j = 2;
			//while (N % j == 0)
			//	j++;
			//k = j;
			for (int i = 0; i < size; i++)
			{
				h[i] = new Film();
			}
		}

		~HeshT()
		{
			h = null;
		}

		int hashkey(string i)
		{
			int h = 0;
			for (int j = 0; j < i.Length; j++)
			{
				h = h + i[j];
			}
			return h;
		}

		int HeshF(int key)
		{
			int sum = 0;

			int hesh = key;
			while (hesh / 100 != 0)
			{
				sum = sum + hesh % 100;
				hesh = hesh / 100;
			}
			sum = (sum + hesh % 100) % size;
			return sum;
		}
		public int First_HF(string i)
        {
			int ind = hashkey(i);
			ind = HeshF(ind);
			return ind;
        }
		int HeshF2(int key, int j)
		{
			return ((key + j * k) % size);
		}

		int Collizia(int key, Film i)
		{
			int ind2 = key;
			int l = 0;
			int j = 1;

			while (l < size)
			{
				ind2 = HeshF2(key, j);
				if (h[ind2].name_f == i.name_f && h[ind2].status == 1) return -1;
				else if (h[ind2].status == 0) return ind2;
				else if (h[ind2].status == 2)
				{
					if (Search_(i.name_f) < 0) return ind2;
					else return -1;
				}
				l++;
				j++;
			}
			return -1;
		}

		int DelCollizia(int ind, string name)
		{
			int ind2 = ind;
			int l = 0;
			int j = 1;

			while (l < size)
			{
				ind2 = HeshF2(ind, j);
				if (h[ind2].name_f == name && h[ind2].status == 1)
					return ind2;
				l++;
				j++;
			}
			return -1;
		}

		void New_F()
		{
			File.WriteAllText("Фильмы.txt", "");
			for (int j = 0; j < size; j++)
			{
				if (h[j].status == 1)
				{
					string str =  h[j].name_f + " | " + h[j].genre +" | "+ h[j].date + "\n";
					File.AppendAllText("Фильмы.txt", str);
				}

			}

		}
		public int Add(Film i)//
		{
			int key = hashkey(i.name_f);
			int ind = HeshF(key);
			if (h[ind].name_f == i.name_f && h[ind].status == 1)
			{
				New_F();
				return ind;
			}
			else if (h[ind].status == 1)
			{
				int ind2 = Collizia(ind, i);
				if (ind2 >= 0)
				{
					h[ind2].name_f = i.name_f;
					h[ind2].genre = i.genre;
					h[ind2].date = i.date;
					h[ind2].status = 1;
					New_F();
				}
				return ind2;
			}
			else if (h[ind].status == 0)
			{
				h[ind].name_f = i.name_f;
				h[ind].genre = i.genre;
				h[ind].date = i.date;
				h[ind].status = 1;
				New_F();
				return ind;
			}
			else if (h[ind].status == 2)
			{
				if (Search_(i.name_f) < 0)
				{
					h[ind].name_f = i.name_f;
					h[ind].genre = i.genre;
					h[ind].date = i.date;
					h[ind].status = 1;
					New_F();
					return ind;
				}
			}
			return -1;
		}

		public int Del(string name)
		{
			int key = hashkey(name);
			int ind = HeshF(key);

			if (h[ind].name_f == name && h[ind].status == 1)
			{
				h[ind].status = 2;
				New_F();
				return ind;
			}
			else
			{
				int ind2 = DelCollizia(ind, name);
				if (ind2 >= 0 && h[ind2].name_f == name)// ind >= 0
				{
					h[ind2].status = 2;
					New_F();
					return ind2;
				}
			}
			return -1;
		}

		//public void WriteT()
		//{
		//	for (int j = 0; j < size; j++)
		//	{
		//		h[j].WriteF();
		//	}
		//}

		public int Search_(string name)
		{
			int key = hashkey(name);
			int ind = HeshF(key);
			int ind2 = ind;
			int l = 0;
			int j = 1;
			while (h[ind2].name_f != " " && l < size)
			{
				if (h[ind2].name_f == name && h[ind2].status == 1)
					return ind2;
				ind2 = HeshF2(ind, j);
				j++;
				l++;
			}
			return -1;
		}

		//public void Search(string name, int y1, int y2)
		//{
		//	int ind = Search_(name);
		//	Program.count++;
		//	if (h[ind].date >= y1 && h[ind].date <= y2)
		//	{
		//		h[ind].WriteF();
		//	}
		//}

		public void Search_File(string name, int y1, int y2)
		{
			int ind = Search_(name);
			if (h[ind].date >= y1 && h[ind].date <= y2)
			{
				string str = h[ind].name_f + " | " + h[ind].genre + " | " + h[ind].date + "\n";
				File.AppendAllText("report.txt", str);
			}
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Курсовой_Проект
{
    class AVL
    {
		public class Node
		{
			public Actor key; //Ключ
			public Node left;        // левый потомок
			public Node right; // правый потомок
			public Spisok coun = new Spisok();// список, для повторяющихся элементов

			public Node()
			{

			}
            public Node(Actor a)
            {
                key = a;
				Spisok coun = new Spisok();
			}
        }

		public Node root = new Node();
		static public Actor[] mas = new Actor[1000];
		static public int ind = 0;

		public int Comparison(Actor a, Node tree) //Сравнение ключей
		{
			Actor act = tree.key;

			string f = act.f;
			string i = act.i;
			string o = act.o;

			if (String.Compare(f, a.f) > 0)
			{
				return (1);
			}
			else if (String.Compare(f, a.f) < 0)
			{
				return (-1);
			}
			else if (String.Compare(f, a.f) == 0)
			{
				if (String.Compare(i, a.i) > 0)
				{
					return (1);
				}
				else if (String.Compare(i, a.i) < 0)
				{
					return (-1);
				}
				else if (String.Compare(i, a.i) == 0)
				{
					if (String.Compare(o, a.o) > 0)
					{
						return (1);
					}
					else if (String.Compare(o, a.o) < 0)
					{
						return (-1);
					}
					else if (String.Compare(o, a.o) == 0)
					{
						return (0);
					}
				}
			}
			return -1;
		}


		void new_FA()
		{
			File.WriteAllText("Актеры.txt", "");
			new_F_A(root);
		}

		void new_F_A(Node act)
		{
			if (act != null)
			{
				new_F_A(act.left);
				string str = act.key.i + " | " + act.key.f + " | " + act.key.o + " | " + act.key.name_f + " | " + act.key.day + "." + act.key.month + "." + act.key.years + "\n";
				File.AppendAllText("Актеры.txt", str);
				if (act.coun != null)
					if (act.coun.act.f != null)
						act.coun.view_begin_file();
				new_F_A(act.right);
			}
		}
		public void Add(Actor act)
		{
			Node tree = new Node(act);
			if(root == null)
            {
				root = tree;
				tree.coun.Clear(tree);
			}
			if (root.key == null)
			{
				root = tree;
			}
			else
			{
				root = RecursiveInsert(root, tree);
				new_FA();
			}
		}

		private Node RecursiveInsert(Node t1, Node t2)
		{
			if (t1 == null)
			{
				t1 = t2;
				return t1;
			}
			else if (Comparison(t2.key, t1) == 1)
			{
				t1.left = RecursiveInsert(t1.left, t2);
				t1 = balance_tree(t1);
			}
			else if (Comparison(t2.key, t1) == -1)
			{
				t1.right = RecursiveInsert(t1.right, t2);
				t1 = balance_tree(t1);
			}
			else if (Comparison(t2.key, t1) == 0)
			{
				t1.coun.Add(t2.key, t1);
			}

			return t1;
		}

		private Node balance_tree(Node t1)
		{
			int b_factor = balance_factor(t1);
			if (b_factor > 1)
			{
				if (balance_factor(t1.left) > 0)
				{
					t1 = RotateLL(t1);
				}
				else
				{
					t1 = RotateLR(t1);
				}
			}
			else if (b_factor < -1)
			{
				if (balance_factor(t1.right) > 0)
				{
					t1 = RotateRL(t1);
				}
				else
				{
					t1 = RotateRR(t1);
				}
			}
			return t1;
		}

		public void Delete_F(string name_f)
		{
			D_F(name_f, root);
			new_FA();
		}

		void D_F(string f, Node t)
		{
			if (t != null)
			{
				D_F(f, t.left);
				if (t.key.name_f == f)
				{
					if (t.coun != null)
						if (t.coun.act.f != null)
						{
							t.coun.Del_Ver(t);
						}
						else
						{
							Delete(t.key);
						}
					else
					{
						Delete(t.key);
					}

				}
				if (t.coun != null)
					if (t.coun.act.f != null)
					{
						t.coun.Del_F(f, t);
					}
				D_F(f, t.right);
			}
		}

		public void Delete(Actor a)
		{//and here
			root = Delete_A(root, a);
			new_FA();
		}
		private Node Delete_A(Node t1, Actor act)
		{
			Node parent;
			if (t1 == null)
			{
				return null;
			}
			else
			{
				if (Comparison(act, t1) == 1)
				{
					t1.left = Delete_A(t1.left, act);
					if (balance_factor(t1) == -2)
					{
						if (balance_factor(t1.right) <= 0)
						{
							t1 = RotateRR(t1);
						}
						else
						{
							t1 = RotateRL(t1);
						}
					}
				}
				else if (Comparison(act, t1) == -1)
				{

					t1.right = Delete_A(t1.right, act);
					if (balance_factor(t1) == 2)
					{
						if (balance_factor(t1.left) >= 0)
						{
							t1 = RotateLL(t1);
						}
						else
						{
							t1 = RotateLR(t1);
						}
					}
				}
				else
				{
					if (t1.coun.act.f != null)
					{
						t1.coun.Clear(t1);
					}
					if (t1.right != null)
					{
						parent = t1.right;

						while (parent.left != null)
						{
							parent = parent.left;
						}
						t1.key = parent.key;
						t1.right = Delete_A(t1.right, parent.key);
						if (balance_factor(t1) == 2)
						{
							if (balance_factor(t1.left) >= 0)
							{
								t1 = RotateLL(t1);
							}
							else { t1 = RotateLR(t1); }
						}
					}
					else
					{
						return t1.left;
					}
				}
			}
			return t1;
		}

		public void Delete_AF(Actor a)
		{//and here
			root = Delete(root, a);
			new_FA();
		}
		private Node Delete(Node t1, Actor act)
		{
			Node parent;
			if (t1 == null)
			{ return null; }
			else
			{
				if (Comparison(act, t1) == 1)
				{
					t1.left = Delete(t1.left, act);
					if (balance_factor(t1) == -2)
					{
						if (balance_factor(t1.right) <= 0)
						{
							t1 = RotateRR(t1);
						}
						else
						{
							t1 = RotateRL(t1);
						}
					}
				}
				else if (Comparison(act, t1) == -1)
				{
					t1.right = Delete(t1.right, act);
					if (balance_factor(t1) == 2)
					{
						if (balance_factor(t1.left) >= 0)
						{
							t1 = RotateLL(t1);
						}
						else
						{
							t1 = RotateLR(t1);
						}
					}
				}
				else
				{
					if (t1.coun.act.f != null)
					{
						t1.coun.Del_F(act.name_f, t1);
					}
					else if (t1.right != null)
					{
						parent = t1.right;
						while (parent.left != null)
						{
							parent = parent.left;
						}
						t1.key = parent.key;
						t1.right = Delete(t1.right, parent.key);
						if (balance_factor(t1) == 2)
						{
							if (balance_factor(t1.left) >= 0)
							{
								t1 = RotateLL(t1);
							}
							else { t1 = RotateLR(t1); }
						}
					}
					else
					{
						return t1.left;
					}
				}
			}
			return t1;
		}
		public void Find(Actor a, string[] mas) 
		{
			Node tmp = Find(a, root, mas);
		}
		private Node Find(Actor act, Node t1, string[] mas)
		{
			if(t1 != null)
            {
				Program.count++;
				if (Comparison(act, t1) == 1)
				{
					if (act.f == t1.key.f && act.i == t1.key.i && act.o == t1.key.o)
					{
						mas[0] = t1.key.name_f;
						t1.coun.Find(mas);
						return t1;
					}
					else
						return Find(act, t1.left, mas);
				}
				else
				{
					if (act.f == t1.key.f && act.i == t1.key.i && act.o == t1.key.o)
					{
						mas[0] = t1.key.name_f;
						t1.coun.Find(mas);
						return t1;
					}
					else
						return Find(act, t1.right, mas);
				}
			}
			return t1;
		}

		public void Find_A(Actor a, Actor[] mas)
		{
			Node tmp = Find_A(a, root, mas);
		}

		private Node Find_A(Actor act, Node t1, Actor[] mas)
		{
			if (t1 != null)
			{
				if (Comparison(act, t1) == 1)
				{
					if (act.f == t1.key.f && act.i == t1.key.i && act.o == t1.key.o)
					{
						mas[0] = t1.key;
						t1.coun.Find_A(mas);
						return t1;
					}
					else
						return Find_A(act, t1.left, mas);
				}
				else
				{
					if (act.f == t1.key.f && act.i == t1.key.i && act.o == t1.key.o)
					{
						mas[0] = t1.key;
						t1.coun.Find_A(mas);
						return t1;
					}
					else
						return Find_A(act, t1.right, mas);
				}
			}
			return t1;
		}
		public void DisplayTree()
		{
			ind = 0;
			Actor[] mas_ = new Actor[1000];
			for (int i = 0; i < 1000; i++)
			{
				mas_[i] = new Actor();
			}
			mas = mas_;
			mas_ = null;

			if (root == null)
			{
				Console.WriteLine("Tree is empty");
				return;
			}
			InOrderDisplayTree(root);
			Console.WriteLine();
		}


		private void InOrderDisplayTree(Node act)
		{
			if (act != null)
			{
				InOrderDisplayTree(act.left);
				mas[ind] = act.key;
				ind++;
				if (act.coun != null)
					if (act.coun.act.f != null)
						act.coun.view_begin();
				InOrderDisplayTree(act.right);
			}
		}
		private int max(int l, int r)
		{
			return l > r ? l : r;
		}
		private int getHeight(Node current)
		{
			int height = 0;
			if (current != null)
			{
				int l = getHeight(current.left);
				int r = getHeight(current.right);
				int m = max(l, r);
				height = m + 1;
			}
			return height;
		}
		private int balance_factor(Node current)
		{
			int l = getHeight(current.left);
			int r = getHeight(current.right);
			int b_factor = l - r;
			return b_factor;
		}
		private Node RotateRR(Node parent)
		{
			Node pivot = parent.right;
			parent.right = pivot.left;
			pivot.left = parent;
			return pivot;
		}
		private Node RotateLL(Node parent)
		{
			Node pivot = parent.left;
			parent.left = pivot.right;
			pivot.right = parent;
			return pivot;
		}
		private Node RotateLR(Node parent)
		{
			Node pivot = parent.left;
			parent.left = RotateRR(pivot);
			return RotateLL(parent);
		}
		private Node RotateRL(Node parent)
		{
			Node pivot = parent.right;
			parent.right = RotateLL(pivot);
			return RotateRR(parent);
		}
	}
}

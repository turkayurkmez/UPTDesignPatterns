namespace Composite
{

    /*
     * Problem:
     * Birbiri içine geçebilen (kendi kendisi ile parent-child ilişkisi kuran) bir nesne koleksiyonunuz var ve bu kolesiyon içinde bellek üzerinde taşıma, sıralama, kopyalama gibi işlemler yapıyorsunuz. En pratik biçimde yapıyı nasıl sağlarsınız?
     */



    public class Category : IComparable<Category>
    {

        public string Name { get; set; }
        public override string ToString()
        {
            return Name;
        }

        public int CompareTo(Category? other)
        {
            return this == other ? 0 : -1;
        }

        public Category(string name)
        {
            Name = name;
        }
    }

    public class CategoryComposite<T> where T : IComparable<T>
    {
        //Leaf: Altına başka eleman EKLENEMEYECEK olan element'dir
        //Non-Leaf: Altına başka eleman EKLENEBİLECEK olan node'dur
        public T Node { get; set; }

        public List<CategoryComposite<T>> Children { get; set; } = new List<CategoryComposite<T>>();

        public CategoryComposite<T> Add(T child)
        {
            CategoryComposite<T> newCategory = new CategoryComposite<T>() { Node = child };
            Children.Add(newCategory);
            return newCategory;
        }

        public static void Show(int level, CategoryComposite<T> composite, TreeView treeView)
        {
            string line = new string('*', level);
            //Console.WriteLine($"{line}{composite.Node}");
            treeView.Nodes.Add($"{line}{composite.Node}");
            foreach (var item in composite.Children)
            {
                Show(level + 1, item, treeView);
            }
        }


    }

}

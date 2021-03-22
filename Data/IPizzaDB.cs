using Model;
using System.Collections.Generic;

namespace Data
{
    interface IPizzaDB
    {
        bool Insert(Pizza pizza);
        List<Pizza> Select();
    }
}

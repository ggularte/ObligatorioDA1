using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IFigureRepository
    {
        void AddFigure(Figure figure);

        void DeleteFigure(Figure figure);

        List<Figure> GetAllFigures();

        Figure GetFigure(Client owner, string figureName);
    }
}

using Domain;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drivers
{
    public class FigureDriver
    {
        private FigureRepository figureRepository;

        public FigureDriver()
        {
            figureRepository = new FigureRepository();
        }

        public void AddFigure(Figure figure)
        {
            figureRepository.AddFigure(figure);
        }

        public void DeleteFigure(Figure figure)
        {
            figureRepository.DeleteFigure(figure);
        }

        public List<Figure> GetAllFigures()
        {
            return figureRepository.GetAllFigures();
        }

        public Figure GetFigure(Client owner, string figureName)
        {
            return figureRepository.GetFigure(owner, figureName);
        }
    }
}

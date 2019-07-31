﻿using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;

namespace Geodex.GH.Curves
{
    public class Periodic : GeodexBase
    {
        /// <summary>
        /// Initializes a new instance of the Periodic class.
        /// </summary>
        public Periodic()
          : base("Periodic Curve Plots", "Periodic Curve", "A series of closed curve equations", "Vector", "Plots")
        {
            entries = new string[] { "Alain", "Besace_A", "Besace_B", "Bifolium", "Biquartic", "BoothsLemniscate", "BoothsOvals", "Cassini", "Circle", "Ellipse", "Folium", "FreethNephroid", "Limacon", "Lissajous", "Plateau", "SuperEllipse", "Teardrop" };
            inputs = new int[] { 2, 2, 2, 2, 1, 2, 2, 1, 1, 2, 2, 1, 2, 3, 2, 3, 1 };
        }

        /// <summary>
        /// Set Exposure level for the component.
        /// </summary>
        public override GH_Exposure Exposure
        {
            get { return GH_Exposure.primary; }
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddNumberParameter("Parameter", "T", "A scalar number parameter most commonly between [0-1], [0,2], and [-1,1]", GH_ParamAccess.item, 0.5);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddTextParameter("Test", "T", "---", GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            double t = 0.5;
            DA.GetData(0, ref t);

            Geodex.Point pt = new Point();

            List<double> v = GetValues(DA);

            switch (entries[index])
            {

                case "Alain":
                    pt = new Geodex.Curves.Closed.Alain(t, v[0], v[1]).Location;
                    break;
                case "Besace A":
                    pt = new Geodex.Curves.Closed.Besace_A(t, v[0], v[1]).Location;
                    break;
                case "Besace B":
                    pt = new Geodex.Curves.Closed.Besace_B(t, v[0], v[1]).Location;
                    break;
                case "Bifolium":
                    pt = new Geodex.Curves.Closed.Bifolium(t, v[0], v[1]).Location;
                    break;
                case "Biquartic":
                    pt = new Geodex.Curves.Closed.Biquartic(t, v[0]).Location;
                    break;
                case "Booths Lemniscate":
                    pt = new Geodex.Curves.Closed.BoothsLemniscate(t, v[0], v[1]).Location;
                    break;
                case "Booths Ovals":
                    pt = new Geodex.Curves.Closed.BoothsOvals(t, v[0], v[1]).Location;
                    break;
                case "Ellipse":
                    pt = new Geodex.Curves.Closed.Ellipse(t, v[0], v[1]).Location;
                    break;
                case "Folium":
                    pt = new Geodex.Curves.Closed.Folium(t, v[0], v[1]).Location;
                    break;
                case "Freeth Nephroid":
                    pt = new Geodex.Curves.Closed.FreethNephroid(t, v[0]).Location;
                    break;
                case "Limacon":
                    pt = new Geodex.Curves.Closed.Limacon(t, v[0], v[1]).Location;
                    break;
                case "Lissajous":
                    pt = new Geodex.Curves.Closed.Lissajous(t, v[0], v[1], v[2]).Location;
                    break;
                case "Plateau":
                    pt = new Geodex.Curves.Closed.Plateau(t, v[0], v[1]).Location;
                    break;
                case "Super Ellipse":
                    pt = new Geodex.Curves.Closed.SuperEllipse(t, v[0], v[1], v[2]).Location;
                    break;
                case "Teardrop":
                    pt = new Geodex.Curves.Closed.Teardrop(t, v[0]).Location;
                    break;
                default:
                    pt = new Geodex.Curves.Closed.Circle(t, v[0]).Location;
                    break;
            }

            DA.SetData(0, new Point3d(pt.X, pt.Y, pt.Z));
        }

        /// <summary>
        /// Provides an Icon for the component.
        /// </summary>
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                //You can add image files to your project resources and access them like this:
                // return Resources.IconForThisComponent;
                return null;
            }
        }

        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("5ba5de58-13d5-41d0-9cb6-b417c7becfe2"); }
        }
    }
}
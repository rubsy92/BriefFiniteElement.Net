﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using BriefFiniteElementNet.Elements;

namespace BriefFiniteElementNet.Materials
{
    /// <summary>
    /// Represents a base class for general 3D materials
    /// </summary>
    public abstract class BaseMaterial : ISerializable
    {
        /// <summary>
        /// Gets the material properties at defined location.
        /// </summary>
        /// <param name="isoCoords">the isometric coordination, order: xi eta gama</param>
        /// <returns>the material of element, in local element's coordination system</returns>
        public abstract AnisotropicMaterialInfo GetMaterialPropertiesAt(params double[] isoCoords);

        /// <summary>
        /// Gets the maximum order (degree) of members of material regarding xi - eta and gama.
        /// </summary>
        /// <remarks>
        /// Will use for determining Gaussian sampling count.
        /// Assuming each property of material is a polynomial function of xi, eta and nu, this will return
        /// maximum degree of polynomial in xi, eta and gama directions.
        /// Ex = 3*xi^2+5*eta^3+1*xi : E: [2,3,0]
        /// Ex = 3*xi^2+5*eta^3+1*xi, nu_xy=7*xi^5 : E: [2,3,0], Nu: [5,0,0] >> result: [5,3,0] (maximum of each one). 
        /// </remarks>
        /// <returns>the number of Gaussian integration points needed in xi, eta ann nu directions</returns>
        public abstract int[] GetMaxFunctionOrder();

        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
        }

        protected BaseMaterial(SerializationInfo info, StreamingContext context)
        {
        }

        public BaseMaterial()
        {
        }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocaluriLibrary.Localuri.MagazineFactories
{
    public interface ILocalFactory
    {
         Locale MakeFastFood( FastFoodType type);
         Locale MakeRestaurant( RestaurantType type);
    }
}
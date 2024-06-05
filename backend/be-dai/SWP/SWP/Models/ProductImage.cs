﻿using System;
using System.Collections.Generic;

namespace SWP.Models;

public partial class ProductImage
{
    public int ProductImageId { get; set; }

    public int ProductStockId { get; set; }

    public string ImageUrl { get; set; } = null!;

    public string? Alt { get; set; }

    public virtual ProductStock ProductStock { get; set; } = null!;
}

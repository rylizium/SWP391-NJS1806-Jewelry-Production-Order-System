﻿using System;
using System.Collections.Generic;

namespace SWP.Models;

public partial class OrderCustomItem
{
    public int OrderItemId { get; set; }

    public int OrderId { get; set; }

    public DateOnly OrderDate { get; set; }

    public int GemstoneId { get; set; }

    public int MetalId { get; set; }

    public int? Size { get; set; }

    public int? Quantity { get; set; }

    public decimal Subtotal { get; set; }

    public virtual ICollection<Design> Designs { get; set; } = new List<Design>();

    public virtual Gemstone Gemstone { get; set; } = null!;

    public virtual Metal Metal { get; set; } = null!;

    public virtual Order Order { get; set; } = null!;

    public virtual ICollection<RequestImage> RequestImages { get; set; } = new List<RequestImage>();
}

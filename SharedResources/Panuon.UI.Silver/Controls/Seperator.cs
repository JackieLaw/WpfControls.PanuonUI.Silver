﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace Panuon.UI.Silver
{
    public class Separator : UIElement
    {
        #region Properties

        #region Thickness
        public double Thickness
        {
            get { return (double)GetValue(ThicknessProperty); }
            set { SetValue(ThicknessProperty, value); }
        }

        public static readonly DependencyProperty ThicknessProperty =
            DependencyProperty.Register("Thickness", typeof(double), typeof(Separator), new FrameworkPropertyMetadata(1.0, FrameworkPropertyMetadataOptions.AffectsRender));
        #endregion

        #region Brush
        public Brush Brush
        {
            get { return (Brush)GetValue(BrushProperty); }
            set { SetValue(BrushProperty, value); }
        }

        public static readonly DependencyProperty BrushProperty =
            DependencyProperty.Register("Brush", typeof(Brush), typeof(Separator), new FrameworkPropertyMetadata(Brushes.Black, FrameworkPropertyMetadataOptions.AffectsRender));
        #endregion

        #region Alignment

        public Alignment Alignment
        {
            get { return (Alignment)GetValue(AlignmentProperty); }
            set { SetValue(AlignmentProperty, value); }
        }

        public static readonly DependencyProperty AlignmentProperty =
            DependencyProperty.Register("Alignment", typeof(Alignment), typeof(Separator), new FrameworkPropertyMetadata(Alignment.Bottom, FrameworkPropertyMetadataOptions.AffectsRender));

        #endregion

        #endregion

        #region Overrides
        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);
            if (RenderSize.Width == 0 || RenderSize.Height == 0)
            {
                return;
            }
            switch (Alignment)
            {
                case Alignment.Left:
                    drawingContext.DrawRectangle(Brush, null, new Rect(0, 0, Thickness, RenderSize.Height));
                    break;
                case Alignment.Right:
                    drawingContext.DrawRectangle(Brush, null, new Rect(RenderSize.Width, 0, Thickness, RenderSize.Height));

                    break;
                case Alignment.Top:
                    drawingContext.DrawRectangle(Brush, null, new Rect(0, 0, RenderSize.Width, Thickness));
                    break;
                default:
                    drawingContext.DrawRectangle(Brush, null, new Rect(0, RenderSize.Height, RenderSize.Width, Thickness));
                    break;
            }
        }
    }
    #endregion
}

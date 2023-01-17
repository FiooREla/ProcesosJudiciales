using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.XtraDataLayout;
using System.Collections;
using DevExpress.XtraEditors;
using System.Windows;
using DevExpress.XtraLayout;
using System.Reflection;
using DevExpress.XtraGrid;

public class ExtLayoutControl : DataLayoutControl
{
    protected override ControlsManager CreateControlsManager()
    {
        return new ExtControlManager();
    }
}

class ExtControlManager : ControlsManager
{
    public ExtControlManager()
    {
        this.InitManager();
    }

    // Public Overrides Sub PerformTypeSpecificActions(control As System.Windows.Forms.Control, elementBi As DevExpress.XtraDataLayout.LayoutElementBindingInfo)
    //     control.Name = control.Name & "1"
    // End Sub
    private ArrayList allSuggestedControls = new ArrayList();
    private ArrayList dateAndTimeControls = new ArrayList();
    private ArrayList numberEditControls = new ArrayList();
    private ArrayList imageControls = new ArrayList();
    private ArrayList boolControls = new ArrayList();
    private ArrayList textControls = new ArrayList();

    public void InitManager()
    {
        boolControls.Add(typeof(GridLookUpEdit));
        boolControls.Add(typeof(CheckEdit));
        imageControls.Add(typeof(PictureEdit));
        imageControls.Add(typeof(ImageEdit));
        numberEditControls.Add(typeof(GridLookUpEdit));
        numberEditControls.Add(typeof(TextEdit));
        textControls.Add(typeof(TextEdit));
        textControls.Add(typeof(GridLookUpEdit));
        dateAndTimeControls.Add(typeof(DateEdit));
        dateAndTimeControls.Add(typeof(TimeEdit));
        allSuggestedControls.Add(typeof(GridLookUpEdit));
        allSuggestedControls.Add(typeof(TextEdit));
        allSuggestedControls.Add(typeof(GridControl));
    }

    public override Type[] GetSuggestedControls(Type dataType)
    {
        if (dataType == typeof(int) || dataType == typeof(Int16) || dataType == typeof(Int32) || dataType == typeof(Int64) || dataType == typeof(float) ||
            dataType == typeof(double) || dataType == typeof(double) || dataType == typeof(Decimal) || dataType == typeof(long))
        {
            //return ToArray(textControls);
            return makeTypes(textControls);
        }
        if (dataType == typeof(DateTime))
        {
            //return ToArray(dateAndTimeControls);
            return makeTypes(dateAndTimeControls);

        }
        if (dataType == typeof(System.Drawing.Bitmap) || dataType == typeof(System.Drawing.Image) || dataType == typeof(System.Drawing.Icon) || dataType == typeof(byte[]))
        {
            //return ToArray(imageControls);
            return makeTypes(imageControls);
        }
        if (dataType == typeof(bool) || dataType == typeof(bool))
        {
            //return ToArray(boolControls);
            return makeTypes(boolControls);
        }
        if (dataType == typeof(string) || dataType == typeof(string))
        {
            //return textControls;
            return makeTypes(textControls);

        }
        //return ToArray(allSuggestedControls);
        return makeTypes(allSuggestedControls);
    }
    private static Type[] makeTypes(ArrayList dataType)
    {
        System.Type[] sType = new Type[dataType.Count];
        int iIndex = 0;
        foreach (Type type in dataType)
        {
            sType[iIndex] = type;
            iIndex = iIndex + 1;
        }

        return sType;
    }
}
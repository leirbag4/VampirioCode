using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VampirioCode.UI.Controls.TabManagement
{
    public delegate void SelectedTabChangedEvent(int index, TabItem item);
    public delegate void UnselectedTabChangedEvent(int index, TabItem item);
    public delegate void TabAddedEvent(int index, TabItem item);
    public delegate void TabRemovedEvent(int index, TabItem item);
    public delegate void StartDragTabEvent(int index, TabItem item);
    public delegate void StopDragTabEvent(int index, TabItem item);
    public delegate void TabIndexChangedEvent(int oldIndex, int newIndex);
    public delegate void RightClickContextEvent(TabItem item);
    public delegate void TabDetachedEvent(int index, TabItem item, int offsetX);
    public delegate void TabItemTextChangedEvent(int index, TabItem item);
    public delegate void CloseTabInvokedEvent(int index, TabItem item);
}

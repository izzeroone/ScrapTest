
Class MainWindow

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        SetupHarburgerBar()
        Business.Business.ThongSoBUS.LoadThongSo()
        Task.Factory.StartNew(Sub()
                                  System.Threading.Thread.Sleep(2500)
                              End Sub).ContinueWith(Sub(ByVal t)
                                                        MainSnackbar.MessageQueue.Enqueue("Chào mừng đến với phần mềm quản lý phòng mạch")
                                                    End Sub, TaskScheduler.FromCurrentSynchronizationContext())


    End Sub

    Public Sub SetupHarburgerBar()
        Dim mainMenuItems As New List(Of Domain.GroupMenuItem)

        Dim menuItems1 As New Domain.GroupMenuItem With {.Name = "PHIẾU KHÁM BỆNH"}
        menuItems1.MenuItems.Add(New Domain.MenuItem() With {.Name = "Lập phiếu khám bệnh", .Content = New ucPhieuKhamBenh()})
        mainMenuItems.Add(menuItems1)

        Dim menuItems2 As New Domain.GroupMenuItem With {.Name = "CHI TIẾT PHIẾU KHÁM"}
        menuItems2.MenuItems.Add(New Domain.MenuItem() With {.Name = "Lập chi tiết phiếu khám", .Content = New ucPhieuKham()})
        mainMenuItems.Add(menuItems2)

        Dim menuItems3 As New Domain.GroupMenuItem With {.Name = "DANH MỤC"}
        menuItems3.MenuItems.Add(New Domain.MenuItem() With {.Name = "Loại bệnh", .Content = New ucLoaiBenh()})
        menuItems3.MenuItems.Add(New Domain.MenuItem() With {.Name = "Loại thuốc", .Content = New ucLoaiThuoc()})
        menuItems3.MenuItems.Add(New Domain.MenuItem() With {.Name = "Loại đơn vị", .Content = New ucLoaiDonVi()})
        menuItems3.MenuItems.Add(New Domain.MenuItem() With {.Name = "Loại cách dùng", .Content = New ucLoaiCachDung()})
        mainMenuItems.Add(menuItems3)
        trvMenu.ItemsSource = mainMenuItems
    End Sub
End Class

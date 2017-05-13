Imports DataAccess.DataAccess
Class MainWindow

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        CauHinhCSDLDAL.WriteCauHinhCSDL()
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

        Dim menuItems1 As New Domain.GroupMenuItem With {.Name = "KHÁM BỆNH"}
        menuItems1.MenuItems.Add(New Domain.MenuItem() With {.Name = "Lập phiếu khám bệnh", .Content = New ucPhieuKhamBenh()})
        menuItems1.MenuItems.Add(New Domain.MenuItem() With {.Name = "Lập chi tiết phiếu khám", .Content = New ucPhieuKham()})
        menuItems1.MenuItems.Add(New Domain.MenuItem() With {.Name = "Lập hóa đơn", .Content = New ucHoaDonThanhToan()})
        mainMenuItems.Add(menuItems1)


        Dim menuItems2 As New Domain.GroupMenuItem With {.Name = "TRA CỨU"}
        menuItems2.MenuItems.Add(New Domain.MenuItem() With {.Name = "Tra cứu bệnh nhân", .Content = New ucTraCuuBenhNhan()})
        menuItems2.MenuItems.Add(New Domain.MenuItem() With {.Name = "Tra cứu bệnh nhân V2", .Content = New ucTraCuuBenhNhanV2()})
        mainMenuItems.Add(menuItems2)

        Dim menuItems3 As New Domain.GroupMenuItem With {.Name = "DANH MỤC"}
        menuItems3.MenuItems.Add(New Domain.MenuItem() With {.Name = "Loại bệnh", .Content = New ucLoaiBenh()})
        menuItems3.MenuItems.Add(New Domain.MenuItem() With {.Name = "Loại thuốc", .Content = New ucLoaiThuoc()})
        menuItems3.MenuItems.Add(New Domain.MenuItem() With {.Name = "Loại đơn vị", .Content = New ucLoaiDonVi()})
        menuItems3.MenuItems.Add(New Domain.MenuItem() With {.Name = "Loại cách dùng", .Content = New ucLoaiCachDung()})
        mainMenuItems.Add(menuItems3)

        Dim menuItems4 As New Domain.GroupMenuItem With {.Name = "CẤU HÌNH"}
        menuItems4.MenuItems.Add(New Domain.MenuItem() With {.Name = "Kết nối CSDL", .Content = New ucCauHinhCSDL()})
        mainMenuItems.Add(menuItems4)

        trvMenu.ItemsSource = mainMenuItems
    End Sub
End Class

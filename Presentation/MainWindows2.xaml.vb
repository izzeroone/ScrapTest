Imports Entities.Entities
Imports Business.Business
Imports DataAccess.DataAccess
Class MainWindows2

    Public Sub SetupHarburgerBar()
        Dim mainMenuItems As New List(Of Domain.GroupMenuItem)

        Dim menuItems0 As New Domain.GroupMenuItem With {.Name = "MÀN HÌNH CHÍNH", .Content = New ucMainMenu()}
        mainMenuItems.Add(menuItems0)

        Dim menuItems1 As New Domain.GroupMenuItem With {.Name = "QUẢN LÝ KHÁM BỆNH"}
        menuItems1.MenuItems.Add(New Domain.MenuItem() With {.Name = "Lập danh sách khám bệnh", .Content = New ucDanhSachKhamBenh()})
        menuItems1.MenuItems.Add(New Domain.MenuItem() With {.Name = "Lập chi tiết phiếu khám", .Content = New ucPhieuKham()})
        menuItems1.MenuItems.Add(New Domain.MenuItem() With {.Name = "Tra cứu bệnh nhân", .Content = New ucTraCuuBenhNhan()})
        mainMenuItems.Add(menuItems1)


        Dim menuItems3 As New Domain.GroupMenuItem With {.Name = "QUẢN LÝ THUỐC"}
        menuItems3.MenuItems.Add(New Domain.MenuItem() With {.Name = "Danh mục loại thuốc", .Content = New ucLoaiThuoc()})
        menuItems3.MenuItems.Add(New Domain.MenuItem() With {.Name = "Danh mục loại đơn vị", .Content = New ucLoaiDonVi()})
        menuItems3.MenuItems.Add(New Domain.MenuItem() With {.Name = "Danh mục loại cách dùng", .Content = New ucLoaiCachDung()})
        menuItems3.MenuItems.Add(New Domain.MenuItem() With {.Name = "Báo cáo sử dụng thuốc", .Content = New ucBaoCaoThuoc()})
        mainMenuItems.Add(menuItems3)

        Dim menuItems6 As New Domain.GroupMenuItem With {.Name = "QUẢN LÝ LOẠI BỆNH"}
        menuItems6.MenuItems.Add(New Domain.MenuItem() With {.Name = "Danh mục loại bệnh", .Content = New ucLoaiBenh()})
        mainMenuItems.Add(menuItems6)

        Dim menuItems4 As New Domain.GroupMenuItem With {.Name = "QUẢN LÝ TÀI CHÍNH"}
        menuItems4.MenuItems.Add(New Domain.MenuItem() With {.Name = "Lập hóa đơn", .Content = New ucHoaDonThanhToan()})
        menuItems4.MenuItems.Add(New Domain.MenuItem() With {.Name = "Báo cáo doanh thu", .Content = New ucBaoCaoDoanhThu()})
        mainMenuItems.Add(menuItems4)

        Dim menuItems5 As New Domain.GroupMenuItem With {.Name = "TỔ CHỨC"}
        menuItems5.MenuItems.Add(New Domain.MenuItem() With {.Name = "Thông số", .Content = New ucThongSo()})
        menuItems5.MenuItems.Add(New Domain.MenuItem() With {.Name = "Kết nối CSDL", .Content = New ucCauHinhCSDL()})
        mainMenuItems.Add(menuItems5)

        trvMenu.ItemsSource = mainMenuItems
    End Sub

    Private Sub trvMenu_SelectedItemChanged(sender As Object, e As RoutedPropertyChangedEventArgs(Of Object))

    End Sub

    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        SetupHarburgerBar()
        ThongSoBUS.LoadThongSo()
        Dim cauHinh As CauHinhCSDLDTO = CauHinhCSDLBUS.GetCauHinhCSDL()
        DataAccessHelper.UpdateCauHinh(cauHinh)
        Task.Factory.StartNew(Sub()
                                  System.Threading.Thread.Sleep(2500)
                              End Sub).ContinueWith(Sub(ByVal t)
                                                        MainSnackbar.MessageQueue.Enqueue("Chào mừng đến với phần mềm quản lý phòng mạch")
                                                    End Sub, TaskScheduler.FromCurrentSynchronizationContext())
    End Sub
End Class

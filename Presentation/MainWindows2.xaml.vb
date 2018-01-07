Imports Entities.Entities
Imports Business.Business
Imports DataAccess.DataAccess
Imports MaterialDesignThemes.Wpf

Class MainWindows2

    Private manHinhChu As New ucMainMenu() ' Màn hình giới thiệu chương trình
    ''' <summary>
    ''' Khởi tạo menu items
    ''' </summary>
    Public Sub SetupMenuItems()

        'Tạo danh sách các màn hình thuộc nhóm khám bệnh
        Dim menuItems1 As New Domain.GroupMenuItem With {.Name = "QUẢN LÝ KHÁM BỆNH"}
        menuItems1.MenuItems.Add(New Domain.MenuItem() With {.Name = "Lập danh sách khám bệnh", .Content = New ucDanhSachKhamBenh()})
        menuItems1.MenuItems.Add(New Domain.MenuItem() With {.Name = "Chuẩn đoán", .Content = New ucChuanDoan()})
        menuItems1.MenuItems.Add(New Domain.MenuItem() With {.Name = "Kê thuốc", .Content = New ucPhieuKham()})
        menuItems1.MenuItems.Add(New Domain.MenuItem() With {.Name = "Tra cứu bệnh nhân", .Content = New ucTraCuuBenhNhan()})
        lvKhamBenh.ItemsSource = menuItems1.MenuItems

        'Tạo danh sách các màn hình thuộc nhóm thuốc
        Dim menuItems2 As New Domain.GroupMenuItem With {.Name = "QUẢN LÝ"}
        menuItems2.MenuItems.Add(New Domain.MenuItem() With {.Name = "Danh mục loại thuốc", .Content = New ucLoaiThuoc()})
        menuItems2.MenuItems.Add(New Domain.MenuItem() With {.Name = "Danh mục loại đơn vị", .Content = New ucLoaiDonVi()})
        menuItems2.MenuItems.Add(New Domain.MenuItem() With {.Name = "Danh mục loại cách dùng", .Content = New ucLoaiCachDung()})
        menuItems2.MenuItems.Add(New Domain.MenuItem() With {.Name = "Danh mục loại bệnh", .Content = New ucLoaiBenh()})
        menuItems2.MenuItems.Add(New Domain.MenuItem() With {.Name = "Danh mục loại dịch vụ", .Content = New ucLoaiDichVu()})
        menuItems2.MenuItems.Add(New Domain.MenuItem() With {.Name = "Báo cáo sử dụng thuốc", .Content = New ucBaoCaoThuoc()})

        lvThuoc.ItemsSource = menuItems2.MenuItems

        'Tạo danh sách các màn hình thuộc nhóm loại bệnh
        Dim menuItems3 As New Domain.GroupMenuItem With {.Name = "QUẢN LÝ LOẠI BỆNH"}

        lvBenh.ItemsSource = menuItems3.MenuItems

        'Tạo danh cách các màn hình thuộc nhóm tài chính
        Dim menuItems4 As New Domain.GroupMenuItem With {.Name = "QUẢN LÝ TÀI CHÍNH"}
        menuItems4.MenuItems.Add(New Domain.MenuItem() With {.Name = "Lập hóa đơn", .Content = New ucHoaDonThanhToan()})
        menuItems4.MenuItems.Add(New Domain.MenuItem() With {.Name = "Báo cáo doanh thu", .Content = New ucBaoCaoDoanhThu()})
        lvTaiChinh.ItemsSource = menuItems4.MenuItems

        'Tạo danh sách các màn hình thuộc nhóm tổ chức
        Dim menuItems5 As New Domain.GroupMenuItem With {.Name = "TỔ CHỨC"}
        menuItems5.MenuItems.Add(New Domain.MenuItem() With {.Name = "Thông số", .Content = New ucThongSo()})
        menuItems5.MenuItems.Add(New Domain.MenuItem() With {.Name = "Kết nối CSDL", .Content = New ucCauHinhCSDL()})
        lvToChuc.ItemsSource = menuItems5.MenuItems

    End Sub

    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        'Tải cấu hình từ file
        Dim cauHinh As CauHinhCSDLDTO = CauHinhCSDLBUS.GetCauHinhCSDL()
        DataAccessHelper.UpdateCauHinh(cauHinh)
    End Sub

    Private Sub listView_MouseLeftButtonUp(sender As Object, e As MouseButtonEventArgs)
        Dim lv As ListView = sender
        If lv.SelectedIndex <> -1 Then
            'Cập nhật màn hình tương ứng với menu
            userControlDisplay.Content = CType(lv.SelectedItem, Domain.MenuItem).Content
        End If
        'Đặt lại các listview
        lvBenh.SelectedIndex = -1
        lvKhamBenh.SelectedIndex = -1
        lvTaiChinh.SelectedIndex = -1
        lvThuoc.SelectedIndex = -1
        lvToChuc.SelectedIndex = -1
    End Sub

    Private Sub HomeButton_Click(sender As Object, e As RoutedEventArgs)
        userControlDisplay.Content = manHinhChu
    End Sub

    Private Async Sub Display_Login(sender As Object, e As RoutedEventArgs)
        Dim dialog As New Domain.LoginDialog
        Await DialogHost.Show(dialog)

        'Kiểm tra thông tin đăng nhập
        If dialog.DialogResult = MessageBoxResult.Yes Then
            Admin_Load()
        Else
            Guest_Load()
        End If
    End Sub


    Private Sub Admin_Load()
        'Hiển thị màn hình chủ
        userControlDisplay.Content = manHinhChu
        'Khởi tạo menu
        SetupMenuItems()
        'Hiển thị thông báo
        Task.Factory.StartNew(Sub()
                                  System.Threading.Thread.Sleep(2500)
                              End Sub).ContinueWith(Sub(ByVal t)
                                                        MainSnackbar.MessageQueue.Enqueue("Chào mừng đến với phần mềm quản lý phòng mạch")
                                                    End Sub, TaskScheduler.FromCurrentSynchronizationContext())
    End Sub

    Private Sub Guest_Load()
        'Hiển thị màn hình chủ
        userControlDisplay.Content = manHinhChu
        'Khởi tạo menu
        Dim menuItems1 As New Domain.GroupMenuItem With {.Name = "QUẢN LÝ KHÁM BỆNH"}
        menuItems1.MenuItems.Add(New Domain.MenuItem() With {.Name = "Tra cứu bệnh nhân", .Content = New ucTraCuuBenhNhan()})
        lvKhamBenh.ItemsSource = menuItems1.MenuItems
        'Hiển thị thông báo
        Task.Factory.StartNew(Sub()
                                  System.Threading.Thread.Sleep(2500)
                              End Sub).ContinueWith(Sub(ByVal t)
                                                        MainSnackbar.MessageQueue.Enqueue("Chào mừng đến với phần mềm quản lý phòng mạch")
                                                    End Sub, TaskScheduler.FromCurrentSynchronizationContext())
    End Sub

End Class

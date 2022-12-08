--giống heo
go
use TRANGTRAINUOIHEO

go
INSERT INTO GIONGHEO VALUES('GH02112022000001', N'Heo Móng Cái', N'Màu sắc lông da trắng, lưng và mông có khoang đen yên ngựa, da mỏng mịn, lông thưa và thô. Đầu to, miệng nhỏ dài, tai nhỏ và nhọn, có nếp nhăn to và ngắn ở miệng. Cổ to và ngắn, ngực nở và sâu, lưng dài và hơi võng, bụng hơi xệ, mông rộng và xuôi. Bốn chân tương đối cao thẳng, móng xoè.
Khối lượng heo sơ sinh: 450-500 gr/ con, heo trưởng thành: 140-170 kg/con. Có con tới 200 kg nhưng thời gian nuôi rất lâu. Tỷ lệ mỡ/thịt xẻ 35-38%.
Sinh sản: Heo đực 3 tháng tuổi biết nhảy cái và trong tinh dịch đã có tinh trùng, lượng tinh dịch 80- 100 ml. Heo cái 3 tháng tuổi đã bắt đầu động hớn nhưng chưa có khả năng thụ thai. Thường thì heo cái đến khoảng 7-8 tháng tuổi trở đi mới có đủ điều kiện tốt nhất cho phối giống và có chửa, thời điểm đó heo đã đạt khối lượng khoảng 40-50 kg hoặc lớn hơn .')
INSERT INTO GIONGHEO VALUES('GH02112022000002', N'Heo Ỉ Pha', N'lông thưa, thô. Lông da đen nhưng không đen bóng như heo Ỉ mỡ. Đầu to vừa phài, trán gần phẳng, mặt nhăn, mọng cổ và má chảy sệ; thân và chân dài và cao hơn so với heo Ỉ mỡ.
Khối lượng sơ sinh 420 gr/con; một năm tuổi 48 – 50 kg/con; 3 năm tuổi 60 – 75 kg/com.
Sinh sản: Lúc 4- 5 tháng tuổi có thể phối giống. Một năm đẻ hai lứa, mỗi lứa từ 8- 11 con.
Chất lượng thịt: Độ dày mỡ đạt 3.66cm. Mỡ nhiều chiếm 42.5% so với thịt xẻ, tích mỡ sớm.')
INSERT INTO GIONGHEO VALUES('GH02112022000003', N'Heo Yorkshire', N'Nguồn gốc Anh, thân hình chữ nhật, có màu trắng, tai đứng hướng nạc mỡ, sinh sản tốt 10 - 12 con/lần, thích nghi cao, heo đực nặng khoảng 250-320 kg, cái khoảng 200-250 kg, tỷ lệ nạc 52-55%.
Đặc biệt dòng heo của úc có ưu điểm tăng trọng nhanh, ít mỡ, nhiều nạc, dễ nuôi dưỡng chăm sóc và có khả năng thích nghi cao với môi trường nhiệt đới nóng ẩm nước ta. Đực Yorkshire 4 chân cao, to khỏe rắn chắc tạo dáng đi linh hoạt, có chất lượng tinh dịch tốt, cho tỷ lệ thụ thai cao và nhiều heo cho mỗi lứa đẻ. Năng suất sinh trưởng và sinh sản của con lai từ đực Yorkshire cũng cao hơn so với những giống khác và thích nghi tốt với điều kiện chăn nuôi nông hộ.')
INSERT INTO GIONGHEO VALUES('GH02112022000004', N'Heo Landrace', N'Nguốn gốc Đan Mạch, thân hình tam giác màu trắng, tai cụp, hướng nạc, sinh sản tốt 8-12 con/lần, thích nghi kém, khối lượng sơ sinh 1,2-1,3 kg/con, con đực trưởng thành 270-300 kg, con cái 200-230 kg, tỷ lệ nạc 54 - 56%.
Dòng đực Landrace có phần mông đặc biệt phát triển, cho nhiều nạc hơn giống Yorkshire, nhưng nhạy cảm với những điều kiện môi trường bất lợi (stress). Dòng nái Lan- drace mỗi lứa đẻ từ 10-14 con, nhưng dễ mắc các bệnh sinh sản như: Mất sữa hoặc viêm nhiễm đường sinh dục')

--loại heo
INSERT INTO LOAIHEO VALUES ('LH02112022000001', N'Heo đực ', N'Là những cá thể heo có những tính trạng tốt được giữ lại làm giống')
INSERT INTO LOAIHEO VALUES ('LH02112022000002', N'Heo nái', N'Là những cá thể heo cái dùng để sinh sản ra những lứa heo mới')
INSERT INTO LOAIHEO VALUES ('LH02112022000003', N'Heo con', N'Là những cá thể heo con trong khoảng từ 21 đến 35 ngày tuổi sau khi sinh vẫn còn bú sữa mẹ')
INSERT INTO LOAIHEO VALUES ('LH02112022000004', N'Heo thịt', N'Là những cá thể heo con sau khoảng từ 21 đến 35 ngày tuổi sau khi sinh được tách ra khỏi mẹ để nhập chuồng nhằm mục đích nuôi thịt')

-- loại chuồng
INSERT INTO LOAICHUONG VALUES('LC03112022000001', N'Chuồng heo nái thịt', N'Là chuồng nuôi cho những con heo cái dùng để lấy thịt')
INSERT INTO LOAICHUONG VALUES('LC03112022000002', N'Chuồng heo đực thịt', N'Là chuồng nuôi cho những con heo đực dùng để lấy thịt')
INSERT INTO LOAICHUONG VALUES('LC03112022000003', N'Chuồng heo nái', N'Là chuồng nuôi những con heo nái dùng để sinh sản')
INSERT INTO LOAICHUONG VALUES('LC03112022000004', N'Chuồng heo đẻ', N'Là chuồng nuôi cho những con heo nái mới đẻ và heo con')
INSERT INTO LOAICHUONG VALUES('LC03112022000005', N'Chuồng heo đực giống', N'Là chuồng nuôi cho những con heo đực dùng để phối giống')

--chuồng
INSERT INTO CHUONGTRAI VALUES ('CH000001000001', 'LC03112022000001', N'Bình thường', '10', '0')
INSERT INTO CHUONGTRAI VALUES ('CH000001000002', 'LC03112022000001', N'Bình thường', '10', '0')
INSERT INTO CHUONGTRAI VALUES ('CH000001000003', 'LC03112022000001', N'Bình thường', '10', '0')
INSERT INTO CHUONGTRAI VALUES ('CH000001000004', 'LC03112022000001', N'Đang sửa chữa', '10', '0')
INSERT INTO CHUONGTRAI VALUES ('CH000001000005', 'LC03112022000001', N'Bình thường', '10', '0')
INSERT INTO CHUONGTRAI VALUES ('CH000002000001', 'LC03112022000002', N'Bình thường', '10', '0')
INSERT INTO CHUONGTRAI VALUES ('CH000002000002', 'LC03112022000002', N'Bình thường', '10', '0')
INSERT INTO CHUONGTRAI VALUES ('CH000002000003', 'LC03112022000002', N'Đang hư hỏng', '10', '0')
INSERT INTO CHUONGTRAI VALUES ('CH000002000004', 'LC03112022000002', N'Bình thường', '10', '0')
INSERT INTO CHUONGTRAI VALUES ('CH000002000005', 'LC03112022000002', N'Đã ngừng sử dụng', '10', '0')
INSERT INTO CHUONGTRAI VALUES ('CH000003000001', 'LC03112022000003', N'Bình thường', '1', '0')
INSERT INTO CHUONGTRAI VALUES ('CH000003000002', 'LC03112022000003', N'Bình thường', '1', '0')
INSERT INTO CHUONGTRAI VALUES ('CH000003000003', 'LC03112022000003', N'Bình thường', '1', '0')
INSERT INTO CHUONGTRAI VALUES ('CH000004000001', 'LC03112022000004', N'Bình thường', '20', '0')
INSERT INTO CHUONGTRAI VALUES ('CH000004000002', 'LC03112022000004', N'Bình thường', '20', '0')
INSERT INTO CHUONGTRAI VALUES ('CH000004000003', 'LC03112022000004', N'Bình thường', '20', '0')
INSERT INTO CHUONGTRAI VALUES ('CH000005000001', 'LC03112022000005', N'Bình thường', '1', '0')
INSERT INTO CHUONGTRAI VALUES ('CH000005000002', 'LC03112022000005', N'Bình thường', '1', '0')
INSERT INTO CHUONGTRAI VALUES ('CH000005000003', 'LC03112022000005', N'Bình thường', '1', '0')


-- Cá thể heo
INSERT INTO HEO VALUES ('HEO001001000001','LH02112022000001', 'GH02112022000001', N'Đực', '10/27/2022', '86', 'CH000004000001', NULL, NULL, N'Nhập ngoài', N'Sức khoẻ tốt')
INSERT INTO HEO VALUES ('HEO001001000002','LH02112022000001', 'GH02112022000001', N'Đực', '12/29/2022', '37', 'CH000004000002', NULL, NULL, N'Nhập ngoài', N'Sức khoẻ tốt')
INSERT INTO HEO VALUES ('HEO001001000003','LH02112022000001', 'GH02112022000001', N'Đực', '11/14/2022', '89', 'CH000004000003', NULL, NULL, N'Sinh trong trang trại', N'Sức khoẻ tốt')
INSERT INTO HEO VALUES ('HEO003001000004','LH02112022000003', 'GH02112022000001', N'Đực', '11/14/2022', '44', 'CH000003000001', 'HEO001001000001', 'HEO003003000013', N'Sinh trong trang trại', N'Sức khoẻ tốt')
INSERT INTO HEO VALUES ('HEO003001000005','LH02112022000003', 'GH02112022000001', N'Cái', '01/23/2022', '94', 'CH000003000001', 'HEO001001000002', 'HEO003003000013', N'Nhập ngoài', N'Đang bị bệnh')
INSERT INTO HEO VALUES ('HEO003001000006','LH02112022000003', 'GH02112022000001', N'Đực', '11/16/2022', '63', 'CH000003000001', 'HEO001001000001', 'HEO003003000013', N'Sinh trong trang trại', N'Sức khoẻ tốt')
INSERT INTO HEO VALUES ('HEO003002000007','LH02112022000003', 'GH02112022000002', N'Đực', '03/06/2022', '11', 'CH000003000001', 'HEO001001000001', 'HEO003003000013', N'Sinh trong trang trại', N'Sức khoẻ tốt')
INSERT INTO HEO VALUES ('HEO003002000008','LH02112022000003', 'GH02112022000002', N'Đực', '06/27/2022', '53', 'CH000003000003', 'HEO001001000001', 'HEO003003000013', N'Sinh trong trang trại', N'Sức khoẻ tốt')
INSERT INTO HEO VALUES ('HEO003002000009','LH02112022000003', 'GH02112022000002', N'Cái', '11/15/2022', '36', 'CH000003000003', 'HEO001001000003', 'HEO003003000012', N'Sinh trong trang trại', N'Sức khoẻ tốt')
INSERT INTO HEO VALUES ('HEO003003000010','LH02112022000003', 'GH02112022000003', N'Cái', '10/26/2022', '46', 'CH000003000002', 'HEO001001000003', 'HEO003003000012', N'Sinh trong trang trại', N'Sức khoẻ tốt')
INSERT INTO HEO VALUES ('HEO003003000011','LH02112022000003', 'GH02112022000003', N'Cái', '09/10/2022', '19', 'CH000003000002', 'HEO001001000003', 'HEO003003000012', N'Sinh trong trang trại', N'Sức khoẻ tốt')
INSERT INTO HEO VALUES ('HEO003003000012','LH02112022000003', 'GH02112022000003', N'Cái', '02/17/2022', '89', 'CH000003000002', 'HEO001001000002', 'HEO003003000012', N'Sinh trong trang trại', N'Đã chết')
INSERT INTO HEO VALUES ('HEO003003000013','LH02112022000002', 'GH02112022000003', N'Cái', '03/10/2022', '98', 'CH000003000003', NULL, NULL, N'Nhập ngoài', N'Đang mang thai')
INSERT INTO HEO VALUES ('HEO003003000014','LH02112022000002', 'GH02112022000003', N'Cái', '01/30/2022', '84', 'CH000003000002', NULL, NULL, N'Nhập ngoài', N'Đang đẻ')
INSERT INTO HEO VALUES ('HEO003003000015','LH02112022000002', 'GH02112022000003', N'Cái', '08/17/2022', '15', 'CH000003000001', NULL, NULL, N'Nhập ngoài', N'Sức khoẻ tốt')
INSERT INTO HEO VALUES ('HEO004004000016','LH02112022000004', 'GH02112022000004', N'Cái', '07/16/2022', '81', 'CH000001000002', NULL, NULL, N'Sinh trong trang trại', N'Sức khoẻ tốt')
INSERT INTO HEO VALUES ('HEO004004000017','LH02112022000004', 'GH02112022000004', N'Đực', '01/01/2022', '57', 'CH000002000002', NULL, NULL, N'Nhập ngoài', N'Sức khoẻ tốt')
INSERT INTO HEO VALUES ('HEO004004000018','LH02112022000004', 'GH02112022000004', N'Đực', '07/27/2022', '51', 'CH000002000003', NULL, NULL, N'Nhập ngoài', N'Sức khoẻ tốt')
INSERT INTO HEO VALUES ('HEO004004000019','LH02112022000004', 'GH02112022000004', N'Cái', '11/27/2022', '70', 'CH000001000001', NULL, NULL, N'Nhập ngoài', N'Sức khoẻ tốt')
INSERT INTO HEO VALUES ('HEO004001000020','LH02112022000004', 'GH02112022000001', N'Đực', '11/22/2022', '97', 'CH000002000001', NULL, NULL, N'Sinh trong trang trại', N'Đang bị bệnh')
INSERT INTO HEO VALUES ('HEO004001000021','LH02112022000004', 'GH02112022000001', N'Đực', '10/17/2022', '61', 'CH000002000001', NULL, NULL, N'Sinh trong trang trại', N'Đang bị bệnh')
INSERT INTO HEO VALUES ('HEO004001000022','LH02112022000004', 'GH02112022000001', N'Đực', '07/17/2022', '82', 'CH000002000001', NULL, NULL, N'Sinh trong trang trại', N'Đang bị bệnh')
INSERT INTO HEO VALUES ('HEO004001000023','LH02112022000004', 'GH02112022000001', N'Cái', '12/01/2022', '39', 'CH000001000001', NULL, NULL, N'Nhập ngoài', N'Sức khoẻ tốt')
INSERT INTO HEO VALUES ('HEO004001000024','LH02112022000004', 'GH02112022000001', N'Cái', '01/00/1900', '19', 'CH000001000001', NULL, NULL, N'Nhập ngoài', N'Đã bị loại thải')

-- PERMISSION 
INSERT INTO PERMISION VALUES ('PER000001', N'Chủ trang trại', 'Admin')
INSERT INTO PERMISION VALUES ('PER000002', N'Nhân viên chăm sóc', '')
INSERT INTO PERMISION VALUES ('PER000003', N'Nhân viên kỹ thuật', '')
INSERT INTO PERMISION VALUES ('PER000004', N'Nhân viên kế toán', '')
INSERT INTO PERMISION VALUES ('PER000005', N'Nhân viên kho', '')
INSERT INTO PERMISION VALUES ('PER000006', N'Quản lý', '')


-- PERMISSION_DETAIL
INSERT INTO PERMISION_DETAIL VALUES ('PD000001', N'Quản lý đàn heo', NULL, 'PER000001')
INSERT INTO PERMISION_DETAIL VALUES ('PD000002', N'Quản lý chuồng nuôi', NULL, 'PER000001')
INSERT INTO PERMISION_DETAIL VALUES ('PD000003', N'Quản lý kho', NULL, 'PER000001')
INSERT INTO PERMISION_DETAIL VALUES ('PD000004', N'Quản lý nhân viên', NULL, 'PER000001')
INSERT INTO PERMISION_DETAIL VALUES ('PD000005', N'Quản lý nhật ký', NULL, 'PER000001')
INSERT INTO PERMISION_DETAIL VALUES ('PD000006', N'Thiết lập cây mục tiêu', NULL, 'PER000001')
INSERT INTO PERMISION_DETAIL VALUES ('PD000007', N'Quản lý thông báo', NULL, 'PER000001')
INSERT INTO PERMISION_DETAIL VALUES ('PD000008', N'Lập phiếu bán heo', NULL, 'PER000001')
INSERT INTO PERMISION_DETAIL VALUES ('PD000009', N'Lập phiếu nhập heo', NULL, 'PER000001')
INSERT INTO PERMISION_DETAIL VALUES ('PD000010', N'Lập phiếu nhập kho', NULL, 'PER000001')
INSERT INTO PERMISION_DETAIL VALUES ('PD000011', N'Lập phiếu xuất kho', NULL, 'PER000001')
INSERT INTO PERMISION_DETAIL VALUES ('PD000012', N'Lập phiếu kiểm kho', NULL, 'PER000001')
INSERT INTO PERMISION_DETAIL VALUES ('PD000013', N'Lập phiếu sửa chữa', NULL, 'PER000001')
INSERT INTO PERMISION_DETAIL VALUES ('PD000014', N'Báo cáo tình trạng đàn heo', NULL, 'PER000001')
INSERT INTO PERMISION_DETAIL VALUES ('PD000015', N'Báo cáo sửa chữa', NULL, 'PER000001')
INSERT INTO PERMISION_DETAIL VALUES ('PD000016', N'Báo cáo tồn kho', NULL, 'PER000001')
INSERT INTO PERMISION_DETAIL VALUES ('PD000017', N'Báo cáo chi tiêu', NULL, 'PER000001')


-- Chức vụ
INSERT INTO CHUCVU VALUES ('CV000001', N'Chủ trang trại ','0', 'PER000001', N'Là người sở hữu và điều hành toàn bộ trang trại')
INSERT INTO CHUCVU VALUES ('CV000002', N'Nhân viên chăm sóc','25000000', 'PER000002', N'Là người chăm sóc và quản lý các cá thể heo trong trang trại')
INSERT INTO CHUCVU VALUES ('CV000003', N'Nhân viên kỹ thuật','15000000', 'PER000003', N'Là người xem xét và kiểm tra hệ thống các chuồng nuôi trong trang trại')
INSERT INTO CHUCVU VALUES ('CV000004', N'Nhân viên kế toán','15000000', 'PER000004', N'Là người quản lý tiền bạc và thống kế chi phí, doanh thu cho trang trại')
INSERT INTO CHUCVU VALUES ('CV000005', N'Nhân viên kho','15000000', 'PER000005', N'là người quản lý hàng hoá và lập phiếu xuất/ nhập kho')
INSERT INTO CHUCVU VALUES ('CV000006', N'Quản lý','15000000', 'PER000006', N'Là người điều hành trang trại có thể thay thế cho chủ trang trại tuy nhiên không có quyền nhân sự và thiết lập mục tiêu cho trang trại')

-- Nhân viên
INSERT INTO NHANVIEN VALUES ('NV000000', N'Hồng Trường Vinh', NULL, NULL, NULL, 'CV000001', N'Nam', '05/26/2002', N'Ktx khu A DHQG TP hồ chí minh', 'Vinh@gmail.com', '0132654789', '11/02/2022', '1', 'Admin', 'Admin') 
INSERT INTO NHANVIEN VALUES ('NV000001', N'Trần Trung Thành', NULL, NULL, NULL, 'CV000002', N'Nam', '09/11/2002', N'Ktx khu A DHQG TP hồ chí minh', 'TendouHakai@gmail.com', '0123456789', '01/12/1900', '4', 'Thanh', '1') 
INSERT INTO NHANVIEN VALUES ('NV000002', N'Triệu Tuấn Tú', NULL, NULL, NULL, 'CV000002', N'Nam', '05/21/2002', N'Ktx khu A DHQG TP hồ chí minh', 'Vippro@gmail.com', '0258741369', '11/15/2022', '1', 'Tu', '1') 
INSERT INTO NHANVIEN VALUES ('NV000003', N'Nguyễn Thành An', NULL, NULL, NULL, 'CV000002', N'Nam', '03/11/2002', N'Ktx khu A DHQG TP hồ chí minh', 'LoanAnh@gmail.com', '0159362478', '11/27/2022', '2', 'An', '1') 
INSERT INTO NHANVIEN VALUES ('NV000004', N'Nguyễn Hữu Việt', NULL, NULL, NULL, 'CV000002', N'Nam', '02/20/2002', N'Ktx khu A DHQG TP hồ chí minh', 'HuuViet@gmail.com', '0162587493', '11/26/2022', '2', 'Viet', '1') 
INSERT INTO NHANVIEN VALUES ('NV000005', N'Nguyễn Phú Thắng', NULL, NULL, NULL, 'CV000002', N'Nam', '02/15/2002', N'Ktx khu A DHQG TP hồ chí minh', 'ThangPhu@gmail.com', '0231445698', '11/15/2022', '4', 'Thang', '1') 
INSERT INTO NHANVIEN VALUES ('NV000006', N'Võ Văn Đăng Khoa', NULL, NULL, NULL, 'CV000003', N'Nam', '03/02/2002', N'Ktx khu A DHQG TP hồ chí minh', 'Yasuo@gmail.com', '0112235647', '11/06/2022', '3', 'Khoa', '1') 
INSERT INTO NHANVIEN VALUES ('NV000007', N'Nguyễn Thanh Vọng', NULL, NULL, NULL, 'CV000003', N'Nam', '07/13/2002', N'Hà Nội', 'Hasagi@gmail.com', '0147984563', '11/26/2022', '4', 'Vong', '1') 
INSERT INTO NHANVIEN VALUES ('NV000008', N'Nguyễn Thăng Long', NULL, NULL, NULL, 'CV000003', N'Nam', '02/09/2002', N'TP Hồ Chí Minh', 'ThaiTo@gmail.com', '0326598741', '11/01/2022', '4', 'Long', '1') 
INSERT INTO NHANVIEN VALUES ('NV000009', N'Trương Thế Toàn', NULL, NULL, NULL, 'CV000004', N'Nam', '03/16/2002', N'TP Hồ Chí Minh', 'Toan@gmail.com', '0551236498', '11/10/2022', '3', 'Toan', '1') 
INSERT INTO NHANVIEN VALUES ('NV000010', N'Phạm Thị Hân', NULL, NULL, NULL, 'CV000006', N'Nữ', '07/09/2002', N'Hà nội', '010202@gmail.com', '0448855123', '11/05/2022', '1', 'Han', '1') 
INSERT INTO NHANVIEN VALUES ('NV000011', N'Nguyễn Thị Diệu', NULL, NULL, NULL, 'CV000005', N'Nữ', '05/02/2002', N'Dĩ An, Bình Dương', 'DieuNguyen@gmail.com', '0321654998', '11/29/2022', '1', 'Dieu', '1') 
INSERT INTO NHANVIEN VALUES ('NV000012', N'Phạm Thị Như Quỳnh', NULL, NULL, NULL, 'CV000005', N'Nữ', '08/26/2002', N'Thủ Dầu 1, Bình Dương', 'BaCuNon@gmail.com', '0126953444', '11/03/2022', '1', 'Quynh', '1') 


-- Đối tác
INSERT INTO DOITAC VALUES ('DT000001', N'Khách hàng ', N'CÔNG TY CỔ PHẦN VISSAN', N'42 Nguyễn Thái Học, Phường Cầu Ông Lãnh, Quận 1, TPHCM', '028 3553 3999', 'vissanco@vissan.com.vn')
INSERT INTO DOITAC VALUES ('DT000002', N'Khách hàng ', N'Kingmeat', N'14/7 Bis Kỳ Đồng, Quận 3, TP. Hồ Chí Minh', '913906653', 'kingmeat.vn')
INSERT INTO DOITAC VALUES ('DT000003', N'Khách hàng ', N'Cửa hàng Organica', N' 130 Nguyễn Đình Chiểu, Phường 6, Quận 3, TP.Hồ Chí Minh', '0286 6733 444', 'thucphamhuuco.vn')
INSERT INTO DOITAC VALUES ('DT000004', N'Khách hàng ', N'High Food Company Limited', N'14/7 Bis Kỳ Đồng, Quận 3, TP. Hồ Chí Minh', '287 6733 350', 'hightFood@gmail.com')
INSERT INTO DOITAC VALUES ('DT000005', N'Khách hàng ', N'Thực phẩm Hoàng Đông', N'Thôn Thanh Vân, Xã Thanh Lâm, Huyện Mê Linh, Hà Nội', '0987 246 161', 'thucphamthanhhuan@gmail.com')
INSERT INTO DOITAC VALUES ('DT000006', N'Nhà cung cấp', N'CÔNG TY CỔ PHẦN CHĂN NUÔI C.P. VIỆT NAM', N'Số 2, Đường 2A, Khu Công nghiệp Biên Hòa II, P. Long Bình Tân, Tp. Biên Hòa, tỉnh Đồng Nai', '02513836 251', 'https://www.cp.com.vn')
INSERT INTO DOITAC VALUES ('DT000007', N'Nhà cung cấp', N'CÔNG TY TNHH CARGILL VIỆT NAM', N'Lầu 4, Cao Ốc Đại Minh Số 77 Hoàng Văn Thái, P. Tân Phú, Quận 7, TP. HCM', '08 5416 1515', 'http://www.cargillfeed.com.vn/')
INSERT INTO DOITAC VALUES ('DT000008', N'đối tác sửa chữa', N'Công ty TNHH Hùng Đồng', N'QL.1A HẠ VÀNG – THIÊN LỘC – CAN LỘC – HÀ TĨNH', '0984 384 939', 'thietbichannuoiheo.com')
INSERT INTO DOITAC VALUES ('DT000009', N'đối tác sửa chữa', N'Thiết Bị Chăn Nuôi Bình An', N'239/4 Đường Lê Văn Quới, P. Bình Trị Đông, Q. Bình Tân,Tp. Hồ Chí Minh (TPHCM)', '985821206', 'levietbinh1969@gmail.com')

-- Hàng hoá
INSERT INTO HANGHOA VALUES ('HH000001', N'Sữa bột cao cấp cho heo con 1010 (Trên 3 ngày tuổi)', '120000', '29', N'Đã hết hạn', N'Thức ăn')
INSERT INTO HANGHOA VALUES ('HH000002', N'Thức ăn HH đặc biệt cho heo con 1922 (Từ 8kg – 15kg)', '80000', '36', N'Vẫn còn', N'Thức ăn')
INSERT INTO HANGHOA VALUES ('HH000003', N'Thức ăn HH đặc biệt cho heo con 8100 (Từ 15 – 25Kg)', '120000', '39', N'Vẫn còn', N'Thức ăn')
INSERT INTO HANGHOA VALUES ('HH000004', N'Thức ăn HH cao cấp cho heo nái mang thai 8042', '50000', '47', N'Vẫn còn', N'Thức ăn')
INSERT INTO HANGHOA VALUES ('HH000005', N'Thức ăn HH cho heo nái cao sản mang thai 1982', '110000', '23', N'Vẫn còn', N'Thức ăn')
INSERT INTO HANGHOA VALUES ('HH000006', N'Thức ăn HH cho heo thịt 1100 (Từ 20Kg – 40Kg)', '80000', '49', N'Vẫn còn', N'Thức ăn')
INSERT INTO HANGHOA VALUES ('HH000007', N'Thức ăn HH cho heo thịt 1302-S (Từ 7 đến 14 ngày trước khi giết mổ)', '70000', '29', N'Vẫn còn', N'Thức ăn')
INSERT INTO HANGHOA VALUES ('HH000008', N'Thức ăn đậm đặc cho heo thịt 1600-S (Từ 20Kg đến xuất chuồng)', '100000', '30', N'Vẫn còn', N'Thức ăn')
INSERT INTO HANGHOA VALUES ('HH000009', N'TILMICOSIN', '70000', '11', N'Vẫn còn', N'Thuốc')
INSERT INTO HANGHOA VALUES ('HH000010', N'IRON-JECT', '50000', '46', N'Vẫn còn', N'Thuốc')
INSERT INTO HANGHOA VALUES ('HH000011', N'Vacxin phó thương hàn', '140000', '48', N'Vẫn còn', N'Vacxin')
INSERT INTO HANGHOA VALUES ('HH000012', N'Vacxin dịch tả lợn ', '50000', '42', N'Vẫn còn', N'Vacxin')
INSERT INTO HANGHOA VALUES ('HH000013', N'Vacxin tụ huyết trùng ', '120000', '11', N'Vẫn còn', N'Vacxin')

INSERT INTO PHIEUHANGHOA VALUES ('001', '03/16/2002','NV000006','NV000001','DT000001', N'Mới tạo', N'Nhập kho',100 )
INSERT INTO PHIEUHANGHOA VALUES ('002', '03/16/2022','NV000006','NV000001','DT000001', N'Mới tạo', N'Nhập kho',100 )
INSERT INTO PHIEUHANGHOA VALUES ('003', '04/15/2022','NV000006','NV000001','DT000001', N'Mới tạo', N'Nhập kho',100 )
INSERT INTO PHIEUHANGHOA VALUES ('004', '04/16/2022','NV000006','NV000001','DT000001', N'Mới tạo', N'Nhập kho',100 )
INSERT INTO PHIEUHANGHOA VALUES ('005', '04/16/2022','NV000006','NV000001','DT000001', N'Mới tạo', N'Nhập kho',100 )
INSERT INTO PHIEUHANGHOA VALUES ('006', '05/16/2022','NV000006','NV000001','DT000001', N'Mới tạo', N'Nhập kho',100 )
INSERT INTO PHIEUHANGHOA VALUES ('007', '06/16/2022','NV000006','NV000001','DT000001', N'Hoàn thành', N'Nhập kho',100 )
INSERT INTO PHIEUHANGHOA VALUES ('008', '08/16/2022','NV000006','NV000001','DT000001', N'Hoàn thành', N'Nhập kho',100 )
INSERT INTO PHIEUHANGHOA VALUES ('009', '08/16/2022','NV000006','NV000001','DT000001', N'Hoàn thành', N'Xuất kho',100 )
INSERT INTO PHIEUHANGHOA VALUES ('0010', '08/16/2022','NV000006','NV000001','DT000001', N'Hoàn thành', N'Xuất kho',100 )
INSERT INTO PHIEUHANGHOA VALUES ('0011', '03/16/2022','NV000006','NV000001','DT000001', N'Hoàn thành', N'Xuất kho',100 )
INSERT INTO PHIEUHANGHOA VALUES ('0012', '10/16/2022','NV000006','NV000001','DT000001', N'Hoàn thành', N'Xuất kho',100 )
INSERT INTO PHIEUHANGHOA VALUES ('0013', '10/16/2022','NV000006','NV000001','DT000001', N'Đã huỷ', N'Xuất kho',100 )
INSERT INTO PHIEUHANGHOA VALUES ('0014', '10/16/2022','NV000006','NV000001','DT000001', N'Đã huỷ', N'Xuất kho',100 )
INSERT INTO PHIEUHANGHOA VALUES ('0015', '12/16/2022','NV000006','NV000001','DT000001', N'Đã huỷ', N'Xuất kho',100 )
INSERT INTO PHIEUHANGHOA VALUES ('0016', '12/16/2022','NV000006','NV000001','DT000001', N'Đã huỷ', N'Xuất kho',100 )

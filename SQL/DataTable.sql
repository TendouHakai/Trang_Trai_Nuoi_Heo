CREATE DATABASE TRANGTRAINUOIHEO

GO
USE TRANGTRAINUOIHEO

--use master
--drop database TRANGTRAINUOIHEO

GO
CREATE TABLE HEO
(
	MaHeo char(16),
	MaLoaiHeo char(16),
	MaGiongHeo char(16),
	GioiTinh varchar(6),
	NgaySinh smalldatetime,
	MaChuong char(16),
	MaHeoCha char(16),
	MaHeoMe char(16),
	NguonGoc varchar(50),
	TinhTrang varchar(50),
	CONSTRAINT PK_HEO PRIMARY KEY (MaHeo)
)

GO
CREATE TABLE LOAIHEO
(
	MaLoaiHeo char(16),
	TenLoaiHeo varchar(50),
	MoTa text,
	CONSTRAINT PK_LH PRIMARY KEY (MaLoaiHeo)
)

GO
CREATE TABLE GIONGHEO
(
	MaGiongHeo char(16),
	TenGiongHeo varchar(50),
	MoTa text,
	CONSTRAINT PK_GH PRIMARY KEY (MaGiongHeo)
)

GO
CREATE TABLE CHUONGTRAI
(
	MaChuong char(16),
	MaLoaiChuong char(16),
	TinhTrang varchar(50),
	SuaChuaToiDa int,
	SoLuongHeo int,
	CONSTRAINT PK_CT PRIMARY KEY (MaChuong)
)

GO
CREATE TABLE LOAICHUONG
(
	MaLoaiChuong char(16),
	TenLoai varchar(50),
	MoTa text,
	CONSTRAINT PK_LCT PRIMARY KEY (MaLoaiChuong)
)



GO
CREATE TABLE LICHTIEMHEO
(
	MaLichTiem char(16),
	MaHeo char(16),
	MaThuoc char(16),
	NgayTiem smalldatetime ,
	LieuLuong int,
	TrangThai Varchar(16),
	CONSTRAINT PK_LTH PRIMARY KEY (MaLichTiem)
)

GO
CREATE TABLE LICHPHOIGIONG
(
	MaLichPhoi char(16),
	MaHeoDuc char(16),
	MaHeoCai char(16),
	Trangthai varchar(50),

	NgayDuKienDe smalldatetime ,
	NgayDeThucTe smalldatetime ,

	SoCon int,
	SoConChet int,
	NgayCaiSua smalldatetime,

	SoConChon smalldatetime,
	CONSTRAINT PK_LPG PRIMARY KEY (MaLichPhoi)
)

Go 
create table HANGHOA 
(
	MaHangHoa char(16),
	TenHangHoa varchar(50),
	DonGia int,
	SoLuongTonKho int,
	TinhTrang varchar(50),
	LoaiHangHoa varchar(50),

	CONSTRAINT PK_HH PRIMARY KEY (MaHangHoa)
)


Go 
create table NHANVIEN 
(
	MaNhanVien char(16),
	HoTen varchar(50),
	MaChucVu char(16),
	GioiTinh varchar(16),
	NgaySinh smalldatetime,
	DiaChi text,
	email text,
	SDT varchar(15),
	NgayVaoLam smalldatetime,
	HeSoLuong int,
	_Username char(50),
	_PassWord char(50),

	CONSTRAINT PK_NV PRIMARY KEY (MaNhanVien)
)

go 
Create table ThongBao
(
	MaThongBao char(16),
	_UserName char(50),
	TieuDe text,
	NoiDung Text,
	ThoiGian time,
	CONSTRAINT PK_TB PRIMARY KEY (MaThongBao)
)

go 
create table CHUCVU
(
	MaChucVu char(16),
	TenChucVu varchar(50),
	LuongCoBan int,
	ID_Permision char(16),

	CONSTRAINT PK_CV PRIMARY KEY (MaChucVu)
)


go
create table PERMISION
(
	ID_Permision char(16),
	Name_Permision varchar(50),
	Permision_Descript text,

	constraint PK_Permision PRIMARY KEY (ID_Permision)
)


go
create table PERMISION_DETAIL
(
	ID_PermisionDetail char(16),
	ActionDetail varchar(50),
	PermisionDetail_Descript text,
	ID_Permision char(16),
	constraint PK_PermisionDetail PRIMARY KEY (ID_PermisionDetail)
)


Go 
Create table DOITAC
(
	MaDoiTac char(16),
	LoaiDoiTac varchar(50),
	TenDoiTac Varchar(200),
	DiaChi text,
	SDT char(15),
	Email text,

	constraint PK_DT PRIMARY KEY (MaDoiTac)
)

Go 
Create table PHIEUSUACHUA
(
	SoPhieu char(16),
	NgaySuaChua smalldatetime,
	MaNhanVien char(16),
	GhiChu text,
	TrangThai varchar(50),
	TongTien int,	
	constraint PK_PSC PRIMARY KEY (SoPhieu)
)

go
create table CT_PHIEUSUACHUA
(
	SoPhieu char(16),
	MaChuong char(16),
	MoTaChiTiet text,
	constraint PK_CT_PSC PRIMARY KEY (SoPhieu, MaChuong)
)

go
Create table PHIEUHEO
(
	SoPhieu char(16),
	NgayLap smalldatetime,
	MaNhanVien char(16),
	MaDoiTac char(16),
	TrangThai varchar(50),
	LoaiPhieu varchar(50),
	TongTien int,

	constraint PK_PH primary key (SoPhieu)
)

Go 
Create table CT_PHIEUHEO
(
	SoPhieu char(16),
	MaHeo char(16),
	TrongLuong int,
	DonGia int,
	constraint PK_CT_PH primary key (SoPhieu, MaHeo)
)


go
Create table PHIEUKIEMKHO
(
	SoPhieu char(16),
	NgayLap smalldatetime,
	MaNhanVien char(16),
	GhiChu text,
	KetQua Text,

	constraint PK_PKK primary key (SoPhieu)
)

Go 
Create table CT_PHIEUKIEMKHO
(
	SoPhieu char(16),
	MaHangHoa char(16),
	SoLuongHienCo int,
	SoLuongKiemTra int,
	constraint PK_CT_PKK primary key (SoPhieu, MaHangHoa)
)

go
Create table	PHIEUHANGHOA
(
	SoPhieu char(16),
	NgayLap smalldatetime,
	MaNhanVien char(16),
	MaDoiTac char(16),
	TrangThai varchar(50),
	LoaiPhieu varchar(50),
	TongTien int,

	constraint PK_PHH primary key (SoPhieu)
)

Go 
Create table CT_PHIEUHANGHOA
(
	SoPhieu char(16),
	MaHangHoa char(16),
	SoLuong int,
	DonGia int,
	constraint PK_CT_PHH primary key (SoPhieu, MaHangHoa)
)

GO 
CREATE TABLE THAMSO
(
	TrongLuongToiThieu int
)


GO
--table Heo--
ALTER TABLE HEO ADD CONSTRAINT FK_H_MLH
FOREIGN KEY (MaLoaiHeo) REFERENCES LOAIHEO(MaLoaiHeo)

ALTER TABLE HEO ADD CONSTRAINT FK_H_MGH
FOREIGN KEY (MaGiongHeo) REFERENCES GIONGHEO(MaGiongHeo)

ALTER TABLE HEO ADD CONSTRAINT FK_H_CT
FOREIGN KEY (MaChuong) REFERENCES CHUONGTRAI(MaChuong)

--table ChuongTrai--
ALTER TABLE CHUONGTRAI ADD CONSTRAINT FK_CT_MC
FOREIGN KEY (MaLoaiChuong) REFERENCES LOAICHUONG(MaLoaiChuong)

--table LICHTIEMHEO--
ALTER TABLE LICHTIEMHEO ADD CONSTRAINT FK_LTH_MH
FOREIGN KEY (MaHeo) REFERENCES HEO(MaHeo)

--table LICHPHOIGIONG--
ALTER TABLE LICHPHOIGIONG ADD CONSTRAINT FK_LPG_MHD
FOREIGN KEY (MaHeoDuc) REFERENCES HEO(MaHeo)

ALTER TABLE LICHPHOIGIONG ADD CONSTRAINT FK_LPG_MHC
FOREIGN KEY (MaHeoCai) REFERENCES HEO(MaHeo)


--table NHANVIEN--
ALTER TABLE NHANVIEN ADD CONSTRAINT FK_NV_MCV
FOREIGN KEY (MaChucVu) REFERENCES CHUCVU(MaChucVu)

--table ThongBao--
--ALTER TABLE ThongBao ADD CONSTRAINT FK_TB_UN
--FOREIGN KEY (_UserName) REFERENCES NHANVIEN(_Username)

--table CHUCVU--
ALTER TABLE CHUCVU ADD CONSTRAINT FK_CV_P
FOREIGN KEY (ID_Permision) REFERENCES PERMISION(ID_Permision)

--table PERMISION_DETAIL--
ALTER TABLE PERMISION_DETAIL ADD CONSTRAINT FK_PD_P
FOREIGN KEY (ID_Permision) REFERENCES PERMISION(ID_Permision)

--table PHIEUSUACHUA--
ALTER TABLE PHIEUSUACHUA ADD CONSTRAINT FK_PSC_MNV
FOREIGN KEY (MaNhanVien) REFERENCES NHANVIEN(MaNhanVien)

ALTER TABLE CT_PHIEUSUACHUA ADD CONSTRAINT FK_CT_PSC_SP
FOREIGN KEY (SoPhieu) REFERENCES PHIEUSUACHUA(SoPhieu)

ALTER TABLE CT_PHIEUSUACHUA ADD CONSTRAINT FK_CT_PSC_MC
FOREIGN KEY (MaChuong) REFERENCES CHUONGTRAI(MaChuong)

--table PHIEUHEO--
ALTER TABLE PHIEUHEO ADD CONSTRAINT FK_PH_MNV
FOREIGN KEY (MaNhanVien) REFERENCES NHANVIEN(MaNhanVien)

ALTER TABLE PHIEUHEO ADD CONSTRAINT FK_PH_MDT
FOREIGN KEY (MaDoiTac) REFERENCES DOITAC(MaDoiTac)

ALTER TABLE CT_PHIEUHEO ADD CONSTRAINT FK_CT_PH_SP
FOREIGN KEY (SoPhieu) REFERENCES PHIEUHEO(SoPhieu)

ALTER TABLE CT_PHIEUHEO ADD CONSTRAINT FK_CT_PH_MH
FOREIGN KEY (MaHeo) REFERENCES HEO(MaHeo)

--table PHIEUHANGHOA--
ALTER TABLE PHIEUHANGHOA ADD CONSTRAINT FK_PHH_MNV
FOREIGN KEY (MaNhanVien) REFERENCES NHANVIEN(MaNhanVien)

ALTER TABLE PHIEUHANGHOA ADD CONSTRAINT FK_PHH_MDT
FOREIGN KEY (MaDoiTac) REFERENCES DOITAC(MaDoiTac)

ALTER TABLE CT_PHIEUHANGHOA ADD CONSTRAINT FK_CT_PHH_SP
FOREIGN KEY (SoPhieu) REFERENCES PHIEUHANGHOA(SoPhieu)

ALTER TABLE CT_PHIEUHANGHOA ADD CONSTRAINT FK_CT_PHH_MHH
FOREIGN KEY (MaHangHoa) REFERENCES HANGHOA(MaHangHoa)

--table PHIEUKIEMKHO--
ALTER TABLE PHIEUKIEMKHO ADD CONSTRAINT FK_PKK_MNV
FOREIGN KEY (MaNhanVien) REFERENCES NHANVIEN(MaNhanVien)

ALTER TABLE CT_PHIEUKIEMKHO ADD CONSTRAINT FK_CT_PKK_SP
FOREIGN KEY (SoPhieu) REFERENCES PHIEUHANGHOA(SoPhieu)

ALTER TABLE CT_PHIEUKIEMKHO ADD CONSTRAINT FK_CT_PKK_MHH
FOREIGN KEY (MaHangHoa) REFERENCES HANGHOA(MaHangHoa)

INSERT INTO PERMISION 
	(ID_Permision,
	Name_Permision,
	Permision_Descript)
VALUES 
	('20221024000001', 
	'ChuTrangTrai', 
	'Admin'); 

INSERT INTO CHUCVU 
	(MaChucVu,
	TenChucVu,
	LuongCoBan,
	ID_Permision)
VALUES 
	('20221024000001', 
	 'ChuTrangTrai', 
	 0,
	 '20221024000001'); 

INSERT INTO NHANVIEN 
	(MaNhanVien,
	HoTen,
	MaChucVu,
	_Username,
	_PassWord)
VALUES 
	('20221024000001', 
	 'HongTruongVinh', 
	 '20221024000001',
	 'Admin',
	 'e3afed0047b08059d0fada10f400c1e5'); 

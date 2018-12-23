INSERT INTO TYPE_LOTTERY VALUES ('LOT001',N'Tp. Hồ Chí Minh');
INSERT INTO TYPE_LOTTERY VALUES ('LOT002',N'Đồng Tháp');
INSERT INTO TYPE_LOTTERY VALUES ('LOT003',N'Cà Mau');
INSERT INTO TYPE_LOTTERY VALUES ('LOT004',N'Bến Tre');
INSERT INTO TYPE_LOTTERY VALUES ('LOT005',N'Vũng Tàu');
INSERT INTO TYPE_LOTTERY VALUES ('LOT006',N'Bạc Liêu');
INSERT INTO TYPE_LOTTERY VALUES ('LOT007',N'Đồng Nai');
INSERT INTO TYPE_LOTTERY VALUES ('LOT008',N'Cần Thơ');
INSERT INTO TYPE_LOTTERY VALUES ('LOT009',N'Sóc Trăng');
INSERT INTO TYPE_LOTTERY VALUES ('LOT010',N'Tây Ninh');
INSERT INTO TYPE_LOTTERY VALUES ('LOT011',N'An Giang');
INSERT INTO TYPE_LOTTERY VALUES ('LOT012',N'Bình Thuận');
INSERT INTO TYPE_LOTTERY VALUES ('LOT013',N'Vĩnh Long');
INSERT INTO TYPE_LOTTERY VALUES ('LOT014',N'Bình Dương');
INSERT INTO TYPE_LOTTERY VALUES ('LOT015',N'Trà Vinh');
INSERT INTO TYPE_LOTTERY VALUES ('LOT016',N'Long An');
INSERT INTO TYPE_LOTTERY VALUES ('LOT017',N'Bình Phước');
INSERT INTO TYPE_LOTTERY VALUES ('LOT018',N'Hậu Giang');

INSERT INTO AGENCY VALUES ('DL001',N'Thành Các',N'75 Minh Phụng, Phường 9, Quận 6','02839695273',1);
INSERT INTO AGENCY VALUES ('DL002',N'Minh Ngọc',N'23 Cách Mạng Tháng 8, Phường 12, Quận 10','02839252755',1);
INSERT INTO AGENCY VALUES ('DL003',N'Bùi Văn Nghĩa',N'6/1 Đinh Bộ Lĩnh - Phường 8 - TP. Mỹ Tho - Tỉnh Tiền Giang','0908919219 ',0);
INSERT INTO AGENCY VALUES ('DL004',N'Cao Mộng Hùng ',N' 59 Duy Tân - KP Lộc Thành - Thị Trấn Trảng Bàng - Huyện Trảng Bàng - Tỉnh Tây Ninh','0913984369 ',0);
INSERT INTO AGENCY VALUES ('DL005',N'Đặng Minh Sơn',N'6/1 Đinh Bộ Lĩnh - Phường 8 - TP. Mỹ Tho - Tỉnh Tiền Giang','0908614439',0);
INSERT INTO AGENCY VALUES ('DL006',N'Bùi Văn Nghĩa',N'31 Cách Mạng Tháng Tám - P.3 - TP. Bến Tre - Tỉnh Bến Tre','0908919219',0);
INSERT INTO AGENCY VALUES ('DL007',N'Đỗ Thị Thùy Liên',N'170 QL 56, xã Hòa Long, Tp. Bà Rịa','0936005601',1);
INSERT INTO AGENCY VALUES ('DL008',N'Đoàn Thái Thanh',N'23/8 Lê Đức Thọ - Phường 16 - Quận Gò Vấp - TP. Hồ Chí Minh','0913751932',1);
INSERT INTO AGENCY VALUES ('DL009',N'Đoàn Thị Quyến',N'Chợ Mỹ Xuân, H.Tân Thành','0908919219 ',0);
INSERT INTO AGENCY VALUES ('DL010',N'Hà Thị Thùy Trang',N'F56/8B - Ấp Hiệp An - Xã Hiệp Tân - H.Hòa Thành - Tây Ninh','0948365194',1);

INSERT INTO DEAL VALUES ('LOT001','DL001',100,80,'2018-10-16',10);
INSERT INTO DEAL VALUES ('LOT001','DL001',80,75,'2018-10-17',10);
INSERT INTO DEAL VALUES ('LOT001','DL001',86,86,'2018-10-18',10);
INSERT INTO DEAL VALUES ('LOT001','DL002',100,90,'2018-11-03',10);
INSERT INTO DEAL VALUES ('LOT002','DL001',100,60,'2018-10-18',10);

INSERT INTO SIGNUP_LOTTERY VALUES ('SUL001','DL001','LOT001','2018-10-16',100);
INSERT INTO SIGNUP_LOTTERY VALUES ('SUL002','DL001','LOT002','2018-10-17',100);
INSERT INTO SIGNUP_LOTTERY VALUES ('SUL001','DL001','LOT001','2018-11-02',100);

INSERT INTO INDEBTEDNESS VALUES ('IND002','LOT001','DL002',10,20,'2018-11-03',810000);
INSERT INTO INDEBTEDNESS VALUES ('IND003','LOT002','DL001',10,20,'2018-10-18',541000);
INSERT INTO INDEBTEDNESS VALUES ('IND004','LOT001','DL001',10,20,'22018-10-16',720000);
INSERT INTO INDEBTEDNESS VALUES ('IND005','LOT001','DL001',10,20,'2018-10-17 ',675000);
INSERT INTO INDEBTEDNESS VALUES ('IND006','LOT001','DL001',10,20,'2018-10-18',774000);

INSERT INTO RECEIPTS VALUES ('IDR001','LOT001','DL002','2018-11-03','2018-12-03',810000);
INSERT INTO RECEIPTS VALUES ('IDR002','LOT002','DL001','2018-10-18','2018-11-15',540000);

INSERT INTO PRIZE VALUES ('PRZ001', N'GIẢI ĐẶC BIỆT',2000000000)
INSERT INTO PRIZE VALUES ('PRZ002', N'GIẢI NHẤT',30000000)
INSERT INTO PRIZE VALUES ('PRZ003', N'GIẢI NHÌ',15000000)
INSERT INTO PRIZE VALUES ('PRZ004', N'GIẢI BA',1000000)
INSERT INTO PRIZE VALUES ('PRZ005', N'GIẢI TƯ',3000000)
INSERT INTO PRIZE VALUES ('PRZ006', N'GIẢI NĂM',1000000)
INSERT INTO PRIZE VALUES ('PRZ007', N'GIẢI SÁU',400000)
INSERT INTO PRIZE VALUES ('PRZ008', N'GIẢI BẢY',200000)
INSERT INTO PRIZE VALUES ('PRZ009', N'GIẢI TÁM',100000)
INSERT INTO PRIZE VALUES ('PRZ010', N'GIẢI PHỤ ĐẶC BIỆT',50000000)
INSERT INTO PRIZE VALUES ('PRZ011', N'GIẢI KHUYẾN KHÍCH',6000000)


use websellphone;
CREATE TABLE `LOG`
(
`id` int(15) NOT NULL AUTO_INCREMENT,
`thongbao` varchar(255)  NULL DEFAULT NULL,
`capdo`  varchar(100)  NULL DEFAULT NULL,
`taikhoan` varchar(255)   NULL DEFAULT NULL,
`diachi` varchar(255)   NULL DEFAULT NULL,
`ip` varchar(255)  NULL DEFAULT NULL,
`ngaythuchien` datetime   NULL DEFAULT NULL,
PRIMARY KEY (`id`)

);

CREATE TABLE `USERROLE`
(
 `id` int(15) NOT NULL AUTO_INCREMENT,
 `username` varchar(255)  NULL DEFAULT NULL,
 `idResource` int(15) NULL DEFAULT NULL ,
 `level` int(15) NULL DEFAULT NULL,
 PRIMARY KEY (`id`)
);


CREATE TABLE `RESOURCE`(
 `id` int(15) NOT NULL AUTO_INCREMENT,
 `control` varchar(255)  NULL DEFAULT NULL,
 `action` varchar(100) NULL DEFAULT NULL ,
 `active` int(15) NULL DEFAULT NULL,
 PRIMARY KEY (`id`)
);

SELECT control,action FROM resource,userrole  WHERE  userrole.username='hien1' and userrole.idResource = resource.id and resource.active =1

INSERT INTO LOG (thongbao, capdo, taikhoan, diachi, ip, ngaythuchien) VALUES ( 'mmm', 'info','aa', '88', '99', NOW())
USE DB_ZompyDogs;

select * from v_DetallesUsuarios;

select * from Menu;

SELECT Nombre_Usuario, Apellido_Usuario,Usuario, Clave, RolID FROM v_DetallesUsuarios;



INSERT INTO Pedido (Fk_Usuario,Fk_Cliente,FechaPedido, total, estado, metodoPago)
VALUES (1, NULL, '2024-10-23 14:30:00', 45.50, 'Completado', 'Tarjeta');

INSERT INTO Pedido (Fk_Usuario, Fk_Cliente, FechaPedido, total, estado, metodoPago)
VALUES (2, NULL, '2024-10-23 15:00:00', 30.00, 'Completado', 'Efectivo');

INSERT INTO Pedido (Fk_Usuario, Fk_Cliente, FechaPedido, total, estado, metodoPago)
VALUES (3, NULL, '2024-10-23 16:00:00', 60.75, 'En preparación', 'Tarjeta');



INSERT INTO Detalle_Pedido (Fk_Pedido, Fk_Menu, Cantidad, precioUnitario, subtotal)
VALUES (1, 1, 2, 239, 2 * 239);

INSERT INTO Detalle_Pedido (Fk_Pedido, Fk_Menu, Cantidad, precioUnitario, subtotal)
VALUES (1, 3, 2, 48, 2 * 48);

INSERT INTO Detalle_Pedido (Fk_Pedido, Fk_Menu, Cantidad, precioUnitario, subtotal)
VALUES (2, 2, 1, 79, 1 * 79);



INSERT INTO Menu (nombrePlatillo, Descripcion, Fk_Categoria, PrecioUnitario, imgPlatillo)
VALUES ('Cervecero','Torta de res (6 oz) a la parrilla, chorizo cervecero Del Corral, lechuga, cebolla, queso mild cheddar, tomate y aderezo',
8, 239, 'hamburguesaCervecera.jpg');

INSERT INTO Menu (nombrePlatillo, Descripcion, Fk_Categoria, PrecioUnitario, imgPlatillo)
VALUES ('Pie de Limón',NULL, 9, 79, 'piedelimon.jpg');

INSERT INTO Menu (nombrePlatillo, Descripcion, Fk_Categoria, PrecioUnitario, imgPlatillo)
VALUES ('Jugo de Naranja Natural',NULL, 10, 48, 'jugodenaranja.jpg');

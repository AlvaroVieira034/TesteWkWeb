INSERT INTO bdtestewkweb.dbo.tab_cliente
SELECT * FROM bdtestewk.dbo.tab_cliente;

INSERT INTO bdtestewkweb.dbo.tab_cliente (des_nomecliente, des_cep, des_cidade, des_uf)
SELECT des_nomecliente, des_cep, des_cidade, des_uf FROM bdtestewk.dbo.tab_cliente;


select * from bdtestewkweb.dbo.Tab_Cliente

select * from tab_produto
select * from bdtestewk.dbo.tab_pedido_item
select * from bdtestewk.dbo.tab_pedido

INSERT INTO bdtestewkweb.dbo.tab_produto (des_descricao, val_preco)
SELECT des_descricao, val_preco FROM bdtestewk.dbo.tab_produto;




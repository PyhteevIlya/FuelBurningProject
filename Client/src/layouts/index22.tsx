import { Link, Outlet } from 'umi';
import './index.less';
import { Button, Form, Input, Layout, Menu } from 'antd';
import { useAccess } from '@umijs/max';
import { Access } from '@umijs/max';
import request from '@/utils/request';

const { Header, Content, Footer } = Layout;


export default () => {
  const access = useAccess();
  const loginHandler = (data: any) => {
    request('https://localhost:7293/Account/Login', { method: 'POST', data }).then((result: any) => {
      localStorage.setItem('token', result.token)
    })
  }

  return (

    <>

      <Access accessible={access.isUser} >
        <Layout className="layout" style={{ height: '100vh' }}>
          <Header>
            <div className="logo" />
            <Menu
              theme="dark"
              mode="horizontal"
              defaultSelectedKeys={['2']}
              items={[
                {
                  label: <Link to="/">Home</Link>,
                  key: 'home',
                },
                {
                  label: <Link to="/raschet">Варианты расчета</Link>,
                  key: 'raschet',
                },
                {
                  label: <Link to="/equip_cond">Отчет</Link>,
                  key: 'equip_cond',
                },
                {
                  label: <Link to="/auth">Auth</Link>,
                  key: 'auth',
                },

              ]}
            />
            <Menu />

          </Header>
          <Content style={{ padding: '0 50px' }}>
            <div className="site-layout-content" style={{ background: '#f5f5f5', paddingTop: '10px' }}>

              <Outlet />

            </div>
          </Content>
          <Footer style={{ textAlign: 'center' }}> Baraban ©2023 </Footer>
        </Layout>

      </Access>

      <Access accessible={!access.isUser} >
        <Form onFinish={loginHandler} layout="inline" style={{ marginBottom: '10px' }}>
          <Form.Item name="login" style={{ width: '250px' }}>
            <Input allowClear placeholder="Логин" />
          </Form.Item>

          <Form.Item name="password" style={{ width: '250px' }}>
            <Input.Password allowClear placeholder="Пароль" />
          </Form.Item>

          <Button type="primary" htmlType="submit">Войти</Button>

        </Form>

      </Access>


    </>

  );
}
function useModel(arg0: string): { initialState: any; setInitialState: any; refresh: any; } {
  throw new Error('Function not implemented.');
}


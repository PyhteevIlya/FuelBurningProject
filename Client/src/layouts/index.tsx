import './index.less';
import { Layout, Menu } from 'antd';
import { useAccess } from '@umijs/max';
import { Access } from '@umijs/max';
import { useModel } from '@umijs/max';
import LoginForm from '@/components/LoginForm';
import { Link } from '@umijs/max';
import { Outlet } from '@umijs/max';


const { Header, Content, Footer } = Layout;

export default () => {

  const { initialState, setInitialState, refresh } = useModel("@@initialState");
  const access = useAccess();



  const logoutHandler = (data: any) => {
    localStorage.removeItem('token');
    setInitialState({});
  };


  return (

    <>
      <Access
        accessible={access.isUser}>
        <Layout className="layout" style={{ minHeight: '100vh' }}>
          <Header>
            <div className="logo" />
            <Menu
              theme="dark"
              mode="horizontal"
              defaultSelectedKeys={['2']}
              items={[
                {
                  label: <Link to="/">Главная</Link>,
                  key: 'home',
                },
                {
                  label: <Link to="/raschet_gas_fuel">Расчет газообразного топлива</Link>,
                  key: 'raschet_gas_fuel',
                },
                {
                  label: <Link to="/raschet_liquid_fuel">Расчет жидкого топлива</Link>,
                  key: 'raschet_liquid_fuel',
                },
                {
                  label: <span onClick={logoutHandler}>Выход</span>,
                  key: 'exit'
                }
              ]}
            />
          </Header>
          <Content style={{ padding: '0 50px' }}>
            <div className="site-layout-content" style={{ background: '#f5f5f5', paddingTop: '10px' }}>

              <Outlet />

            </div>
          </Content>
          <Footer style={{ textAlign: 'center' }}> Разработка информационной системы расчета горения всех видов топлив ©2024 </Footer>
        </Layout>

      </Access>

      <Access
        accessible={!access.isUser}>
        <Layout className="layout">
          <Header>
            <div className="logo" />
          </Header>

        </Layout>

        <LoginForm />
        
        <Content style={{ padding: '0 50px' }}>
          <div className="site-layout-content" style={{ paddingTop: '10px' }}>

          </div>
        </Content>
      </Access>
    </>
  );
};





























{/* <Form onFinish={loginHandler} layout="inline" style={{ marginBottom: '10px' }}>
          <Form.Item name="login" style={{ width: '230px' }}>
            <Input allowClear placeholder="Введите логин" />
          </Form.Item>

          <Form.Item name="password" style={{ width: '230px' }}>
            <Input.Password allowClear placeholder="Введите пароль" />
          </Form.Item>

          <Button type="primary" htmlType="submit">Войти</Button>

        </Form> */}
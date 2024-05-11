import request from "@/utils/request";
import { UserOutlined, LockOutlined } from "@ant-design/icons";
import { useModel } from "@umijs/max";
import { Button, Checkbox, Form, Input, Modal, Row, Select, message } from "antd";
import { useEffect } from "react";

export default (props: any) => {

    const { initialState, setInitialState, refresh } = useModel("@@initialState");

    const loginHandler = async (data: any) => {
        const endpoints = [
            'https://localhost:7293/Account/Login',
            'https://localhost:7100/Account/Login',
            'https://localhost:7050/Account/Login',
        ];
    
        try {
            for (const endpoint of endpoints) {
                try{
                    request(endpoint, { method: 'POST', data }).then((result: any) => {

                        if (result.status === 0) {
                            localStorage.setItem('token', result.token);
                            setInitialState({ a: 1 });
                            //return; 
                        }
    
                    });
                } catch (error) {
                    console.log(`Error for ${endpoint}:`, error);
                    
                }

            }
    

            // message.error("Некорректные логин и(или) пароль");
        } catch (error) {

            console.log('Error:', error);
            message.error("Произошла ошибка при выполнении запроса");
        }
    }; 


    useEffect(() => {
        // Change document title here
        document.title = "Авторизация";
    }, []);

    return (
        <>
            <Row justify="center" align="middle" style={{ minHeight: '50vh' }}>
                <Form
                    name="normal_login"
                    className="login-form"
                    initialValues={{ remember: true }}
                    onFinish={loginHandler}
                >
                    <Form.Item
                        name="login"
                        rules={[{ required: true, message: 'Введите имя пользователя!' }]}
                    >
                        <Input
                            allowClear
                            prefix={<UserOutlined className="site-form-item-icon" />}
                            placeholder="Имя пользователя" />
                    </Form.Item>
                    <Form.Item
                        name="password"
                        rules={[{ required: true, message: 'Введите ваш пароль!' }]}
                    >
                        <Input.Password
                            allowClear
                            prefix={<LockOutlined className="site-form-item-icon" />}
                            type="password"
                            placeholder="Пароль"
                        />
                    </Form.Item>


                    <Form.Item>
                        <Button type="primary" htmlType="submit" className="login-form-button">
                            Войти
                        </Button>
                        {/* <Link to={'/register'} >Зарегистрироваться</Link> */}
                    </Form.Item>
                </Form>
            </Row>
        </>
    );
};



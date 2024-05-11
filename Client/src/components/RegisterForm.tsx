import request from "@/utils/request";
import { UserOutlined, LockOutlined } from "@ant-design/icons";
import { Link, useModel } from "@umijs/max";
import { Button, Form, Input, Row, message } from "antd";
import { history } from "@umijs/max";

export default (props: any) => {

    const { initialState, setInitialState, refresh } = useModel("@@initialState");


    const registerHandler = (data: any) => {
        request('https://localhost:7293/Account/Register', { method: 'POST', data }).then((result: any) => {
            if (result.status == 0) {
                localStorage.setItem('token', result.token);
                setInitialState({ a: 1 });

            }
            else {
                message.error("Ошибка авторизации");

            }
            history.push('/index');


        })
    };

    return (
        <>
            <Row justify="center" align="middle" style={{ minHeight: '50vh' }}>
                <Form
                    name="normal_login"
                    className="login-form"
                    initialValues={{ remember: true }}
                    onFinish={registerHandler}>

                    <Form.Item
                        name="login"
                        rules={[{ required: true, message: 'Введите имя пользователя!' }]}>
                        <Input
                            allowClear
                            prefix={<UserOutlined className="site-form-item-icon" />}
                            placeholder="Имя пользователя" />
                    </Form.Item>

                    <Form.Item
                        name="password"
                        rules={[{ required: true, message: 'Введите ваш пароль!' }]}>

                        <Input.Password
                            allowClear
                            prefix={<LockOutlined className="site-form-item-icon" />}
                            type="password"
                            placeholder="Пароль"/>
                    </Form.Item>

                    <Form.Item>
                        <Button type="primary" htmlType="submit" className="login-form-button">
                            Создать
                        </Button>
                    </Form.Item>

                </Form>
            </Row>
        </>
    );
};



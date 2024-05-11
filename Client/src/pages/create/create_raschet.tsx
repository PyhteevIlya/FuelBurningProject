import { history } from "@umijs/max";
import request from "@/utils/request";
import { Button, Form, message, Spin, } from "antd";
import FormRaschetEdit from "@/components/FormRaschetEdit";
import React from "react";

const DocsPage = (props: any) => {

  const createHandler = (data: any) => {
    console.log(data)

    request(`https://localhost:7293/Home/DataInputAdd`, { method: 'POST', data }).then(result => {
      history.push('/raschet');
      message.success("Запись добавлена")
    });

  }

  React.useEffect(() => {
    // Change document title here
    document.title = "Новая запись";
  }, []);


  return (
    <>

      <Form onFinish={createHandler}>
        <Form.Item name="id" hidden></Form.Item>
        <FormRaschetEdit />
        <Button type="primary" htmlType="submit">Сохранить</Button>

      </Form>



    </>
  );
};

export default DocsPage;

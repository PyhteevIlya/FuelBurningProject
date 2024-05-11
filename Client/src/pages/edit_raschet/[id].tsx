import { useParams, history } from "@umijs/max";
import request from "@/utils/request";
import { Button, Form, message, Spin, } from "antd";
import React from "react";
import FormRaschetEdit from "@/components/FormRaschetEdit";

const DocsPage = (props: any) => {
  const params = useParams();
  const [data, setData] = React.useState();


  React.useEffect(() => {
    request(`https://localhost:7293/Home/DataInputEdit?id=${params.id}`).then(result => {
      console.log(result);
      setData(result);
    });
      document.title = `Редактирование `;

  }, []);

  const editHandler = (data: any) => {
    console.log(data)

    request(`https://localhost:7293/Home/DataInputEdit?id=${params.id}`, { method: 'POST', data }).then(result => {
      history.push('/raschet');
      message.success("Данные сохранены")
    });

  }

  const [form] = Form.useForm();

  return (
    <>

      {data ? <Form onFinish={editHandler} form={form} initialValues={data}>
        <Form.Item name="id" hidden></Form.Item>
        <FormRaschetEdit />
        <Button type="primary" htmlType="submit">Сохранить</Button>

      </Form> : <Spin />}

    </>
  );
};

export default DocsPage;

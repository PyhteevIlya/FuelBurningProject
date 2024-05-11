import { request } from "@umijs/max";

const myRequest = (url: string, opts: any = { method: 'GET' }) => {
    const token = localStorage.getItem('token');
    const headers = opts?.headers ?? {};
    const authHeaders = {...headers, Authorization: 'Bearer ' + token }
    const config = { ...opts, headers: authHeaders };

    return request(url, config)
        .then(result => {
        return result;
    })
        .catch((error: Error) => {
            console.error(`Error in myRequest for ${url}:`, error);
            throw error; 
            // console.log(error);
            // return undefined;
        });

  };

  export default myRequest;
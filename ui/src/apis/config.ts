import { Configuration } from "@/apis-gen";
const config = new Configuration({
  basePath: "https://localhost:7254",
  accessToken: (name, scopes) => {
    console.log(name);

    return (
      localStorage.getItem("token")?.replace('"', "").replace('"', "") ?? ""
    );
  },
  credentials: "include",
  middleware: [
    {
      pre: (context) => {
        let token =
          localStorage.getItem("token")?.replace('"', "").replace('"', "") ??
          "";

        console.log("headers", context.init.headers);
        return new Promise((resolve, reject) => {
          context.init.headers = {
            ...context.init.headers,
            Authorization: token,
          };
          resolve(context);
        });
      },
      post(context) {
        return new Promise((resolve, reject) => {
          console.log("post", context);
          if (context.response.status == 200) {
            resolve();
          }

          reject();
        });
      },
    },
  ],
});

export default config;

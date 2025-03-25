import Axios from "axios";

const API_URL = "http://localhost:5026/api/User";

export async function login({ email, password }) {
  try {
    const response = await Axios.post(`${API_URL}/login`, {
      email,
      password,
    });
    console.log(response.data);
    return response.data;
  } catch (error) {
    throw new Error(error.response.data.message);
  }
}

export async function register(username, password, email) {
  try {
    const response = await Axios.post(`${API_URL}/register`, {
      username,
      password,
      email,
    });
    return response;
  } catch (error) {
    throw new Error(error.response.message);
  }
}

export default {
  login,
  register,
};

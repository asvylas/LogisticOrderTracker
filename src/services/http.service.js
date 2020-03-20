import Axios from "axios";

export default {
  getAll(resource) {
    return Axios.get(`/api/${resource}`);
  },

  get(resource, id) {
    return Axios.get(`/api/${resource}/${id}`);
  },

  create(resource, data) {
    return Axios.post(`/api/${resource}`, data);
  },

  update(resource, id, data) {
    return Axios.put(`/api/${resource}/${id}`, data);
  },

  delete(resource, id) {
    return Axios.delete(`/api/${resource}/${id}`);
  }
};

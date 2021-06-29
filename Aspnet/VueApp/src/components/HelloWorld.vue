<template>
  <div class="hello">
    <h1>{{ msg }}</h1>
    <ul>
      <li v-for="(person,index) of people" :key="index+person.name">{{person.name}}, {{person.age}}</li>
    </ul>
  </div>
</template>

<script>
export default {
  name: 'HelloWorld',
  props: {
    msg: String,
  },
  data: () => ({
    people: []
  }),
  created() {
    this.loadUsers()
  },
  methods: {
    async loadUsers() {
      let response = await fetch("http://localhost:5000/api/person")
      let data = await response.json();
      console.log(data);
      this.people = data
    }
  }
}
</script>

<style scoped>
h3 {
  margin: 40px 0 0;
}
ul {
  list-style-type: none;
  padding: 0;
}
li {
  margin: 0 10px;
}
a {
  color: #42b983;
}
</style>

<template>
  <div>callback</div>
</template>

<script>
export default {
  name: 'callback',
  created() {
    this.$userManager.signinRedirectCallback().then(
      (u) => {
        window.history.replaceState(
          {},
          window.document.title,
          window.location.origin + window.location.pathname
        );
        window.location = '/';
      },
      (error) => {
        console.log(error);
      }
    );
  },
};
</script>